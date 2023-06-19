using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using JapPlatformBackend.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class SelectionRepository : BaseRepository<Selection, CreateSelectionDto,
        UpdateSelectionDto, GetSelectionDto>, ISelectionRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public SelectionRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override async Task<GetSelectionDto> Create(CreateSelectionDto newSelection)
        {
            var program = await context.Programs
               .FirstOrDefaultAsync(p => p.Id == newSelection.ProgramId)
               ?? throw new ResourceNotFound("Program");

            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == newSelection.StudentId)
                ?? throw new ResourceNotFound("Student");

            var ips = context.ItemProgramStudents.Where(ips => ips.StudentId == newSelection.StudentId).ToList();
            context.ItemProgramStudents.RemoveRange(ips);

            var selection = mapper.Map<Selection>(newSelection);

            selection.Students.Add(student);

            context.Selections.Add(selection);
            await context.SaveChangesAsync();

            program = await context.Programs
                .Include(p => p.Selections)
                    .ThenInclude(s => s.Students)
                        .ThenInclude(s => s.ItemProgramStudents)
                .Include(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
                    .ThenInclude(ip => ip.Item)
                .FirstOrDefaultAsync(p => p.Id == program.Id)
               ?? throw new ResourceNotFound("Program");

            for (int i = 0; i < program.ItemPrograms.Count; i++)
            {

                var duration = Math.Ceiling((double)program.ItemPrograms[i].Item.WorkHours / 8);
                var startDate = i == 0 ? student.Selection.StartDate : program.ItemPrograms[i - 1].ItemProgramStudents[0].EndDate;
                var endDate = i == 0 ? student.Selection.StartDate.AddDays(duration) : startDate?.AddDays(duration);

                context.ItemProgramStudents.Add(new ItemProgramStudent
                {
                    ItemProgramId = program.ItemPrograms[i].Id,
                    StudentId = student.Id,
                    StartDate = startDate,
                    EndDate = endDate,

                });

            }
            program.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
        public override async Task<GetSelectionDto> Update(int id, UpdateSelectionDto updatedSelection)
        {
            var selection = await context.Selections
                .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == id)
               ?? throw new ResourceNotFound("Selection");

            selection = mapper.Map(updatedSelection, selection);

            selection.ModifiedAt = DateTime.Now;

            if ((updatedSelection.ProgramId != selection.ProgramId)
                              || (selection.StartDate.Date == updatedSelection.StartDate.Date))
            {
                List<int?> studentIds = selection.Students.Select(s => s?.Id).ToList();
                var oldIPS = context.ItemProgramStudents
                    .Where(ips => studentIds.Contains(ips.StudentId))
                    .ToList();
                context.ItemProgramStudents.RemoveRange(oldIPS);
                await context.SaveChangesAsync(); ;

                var students = await context.Students
                    .Where(s => s.SelectionId == id)
                    .Include(p => p.ItemProgramStudents)
                    .Include(s => s.Selection)
                        .ThenInclude(s => s.Program)
                            .ThenInclude(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
                            .ThenInclude(ips => ips.Item)


                    .ToListAsync();

                var ips = Calc.SetItemsStartEndDates(students);

                context.ItemProgramStudents.AddRange(ips);
            }
            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
        public async Task<GetSelectionDto> AddStudent(int studentId, int slectionId)
        {
            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId)
                ?? throw new ResourceNotFound("Student");

            var selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId)
                ?? throw new ResourceNotFound("Selection");

            var studentExists = selection.Students.Any(s => s.Id == studentId);

            if (studentExists)
                throw new BadRequestException("Student is already in this selection");

            selection.ModifiedAt = DateTime.Now;
            student.ModifiedAt = DateTime.Now;

            selection.Students.Add(student);

            var oldIPS = context.ItemProgramStudents.Where(ips => ips.StudentId == studentId).ToList();
            context.ItemProgramStudents.RemoveRange(oldIPS);
            await context.SaveChangesAsync();

            var students = await context.Students
                .Where(s => s.Id == studentId)
                .Include(s => s.Selection)
                    .ThenInclude(s => s.Program)
                        .ThenInclude(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
                            .ThenInclude(ips => ips.Item)
                .ToListAsync();

            var ips = Calc.SetItemsStartEndDates(students);

            context.ItemProgramStudents.AddRange(ips);

            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
        public async Task<GetSelectionDto> RemoveStudent(int studentId, int slectionId)
        {

            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId && s.Selection.Id == slectionId)
                ?? throw new ResourceNotFound("Student");

            var selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId)
                ?? throw new ResourceNotFound("Selection");

            var ips = await context.ItemProgramStudents
                .Where(ips => ips.StudentId == studentId)
                .ToArrayAsync();

            if (ips.Length > 0)
            {
                context.ItemProgramStudents.RemoveRange(ips);
            }

            selection.ModifiedAt = DateTime.Now;
            student.ModifiedAt = DateTime.Now;

            student.ItemProgramStudents.RemoveAll(s => s.StudentId == studentId);

            selection.Students.Remove(student);
            await context.SaveChangesAsync();

            return mapper.Map<GetSelectionDto>(selection);
        }
    }
}
