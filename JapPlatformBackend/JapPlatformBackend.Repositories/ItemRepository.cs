using AutoMapper;
using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Entities.Base;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class ItemRepository : BaseRepository<Item, CreateItemDto, UpdateItemDto, GetItemDto>, IItemRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public ItemRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GetItemDto>> GetEventsByProgram(int programId)
        {
            var program = await context.Programs
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == programId);

            var events = program.Items
                .Where(i => i.Discriminator == "Event");

            return events.Select(i => mapper.Map<GetItemDto>(i)).ToList();
        }

        public async Task<bool> CreateEventAndAddToProgram(CreateEventDto newEvent)
        {
            var program = await context.Programs
                .Include(p => p.ItemPrograms)
                .FirstOrDefaultAsync(p => p.Id == newEvent.ProgramId);

            var e = new Event
            {
                Name = newEvent.Name,
                WorkHours = newEvent.WorkHours,
            };

            context.Events.Add(e);

            program.ItemPrograms.Add(new ItemProgram
            {
                Item = e,
                Program = program,
                OrderNumber = newEvent.OrderNumber
            });

            await context.SaveChangesAsync();

            return true;
        }
    }
}
