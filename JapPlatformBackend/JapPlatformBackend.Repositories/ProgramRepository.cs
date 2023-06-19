using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Program;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using JapPlatformBackend.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class ProgramRepository : BaseRepository<Program, CreateProgramDto, UpdateProgramDto, GetProgramDto>, IProgramRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ProgramRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override async Task<GetProgramDto> GetById(int id, string includes = "")
        {
            var program = await context.Programs
                .Include(p => p.Selections)
                .Include(p => p.ItemPrograms.OrderBy(p => p.OrderNumber))
                    .ThenInclude(ip => ip.Item)
                .FirstOrDefaultAsync(p => p.Id == id);

            return mapper.Map<GetProgramDto>(program);
        }
        public override async Task<GetProgramDto> Create(CreateProgramDto newProgram)
        {

            var program = mapper.Map<Program>(newProgram);

            context.Programs.Add(program);

            var itemsIds = newProgram.ItemPrograms.Select(ip => ip.ItemId);

            //Checking if all ids are from existing Items
            var validIds = itemsIds.All(id => context.Items.Select(p => p.Id).Contains(id));

            if (!validIds)
                throw new BadRequestException("Item ids are not valid");

            await context.SaveChangesAsync();
            return mapper.Map<GetProgramDto>(program);
        }
        public override async Task<GetProgramDto> Update(int id, UpdateProgramDto newProgram)
        {

            var program = await context.Programs
                .Include(p => p.ItemPrograms)
                    .ThenInclude(ip => ip.ItemProgramStudents)
                .FirstOrDefaultAsync(p => p.Id == id)
               ?? throw new ResourceNotFound("Program");

            program.Name = newProgram.Name;
            program.Description = newProgram.Description;

            var newItemPrograms = newProgram.ItemPrograms
                .OrderBy(ip => ip.OrderNumber)
                .Select(ip => mapper.Map<ItemProgram>(ip))
                .ToList();

            var oldIPS = program.ItemPrograms
                .Select(ip => ip.ItemProgramStudents)
                .SelectMany(ips => ips)
                .ToList();

            program.ItemPrograms.RemoveAll(ip => ip.ProgramId == id);
            program.ItemPrograms.AddRange(newItemPrograms);

            context.ItemProgramStudents.RemoveRange(oldIPS);
            await context.SaveChangesAsync();

            program = await context.Programs
                .Include(p => p.Selections)
                    .ThenInclude(s => s.Students)
                        .ThenInclude(s => s.ItemProgramStudents)
                .Include(p => p.ItemPrograms)
                    .ThenInclude(ip => ip.Item)
                .FirstOrDefaultAsync(p => p.Id == id)
               ?? throw new ResourceNotFound("Program");

            var students = program.Selections.Select(s => s.Students).SelectMany(s => s).ToList();

            var ips = Calc.SetItemsStartEndDates(students);

            context.ItemProgramStudents.AddRange(ips);

            program.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();

            return mapper.Map<GetProgramDto>(program);
        }

        public async Task<GetProgramDto> AddItem(int programId, AddItemPrograms itemProgram)
        {
            var program = await context.Programs
                .FirstOrDefaultAsync(s => s.Id == programId)
                ?? throw new ResourceNotFound("Program");

            var item = await context.Items
                .FirstOrDefaultAsync(s => s.Id == itemProgram.ItemId)
                ?? throw new ResourceNotFound("Item");

            program.ModifiedAt = DateTime.Now;
            var newItemProgram = new ItemProgram
            {
                Program = program,
                Item = item,
                OrderNumber = itemProgram.OrderNumber,
            };

            program.ItemPrograms.Add(newItemProgram);
            await context.SaveChangesAsync();

            return mapper.Map<GetProgramDto>(program);
        }

        public async Task<GetProgramDto> RemoveItem(int programId, int itemId)
        {
            var program = await context.Programs
                .FindAsync(programId)
                ?? throw new ResourceNotFound("Program");

            var itemProgram = context.ItemPrograms.FirstOrDefault(ip => ip.ItemId == itemId && ip.ProgramId == programId);

            context.ItemPrograms.Remove(itemProgram);

            await context.SaveChangesAsync();

            return mapper.Map<GetProgramDto>(program);
        }
    }
}
