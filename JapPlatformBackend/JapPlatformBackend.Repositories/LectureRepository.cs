using AutoMapper;
using JapPlatformBackend.Api.Exceptions;
using JapPlatformBackend.Core.Dtos.Lecture;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;
using JapPlatformBackend.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories
{
    public class LectureRepository : BaseRepository<Lecture, CreateLectureDto, UpdateLectureDto, GetLectureDto>, ILectureRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public LectureRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public override async Task<GetLectureDto> Update(int id, UpdateLectureDto updatedLecture)
        {
            var lecture = await context.Items
                .FirstOrDefaultAsync(s => s.Id == id)
               ?? throw new ResourceNotFound("Lecture");

            if (lecture.WorkHours != updatedLecture.WorkHours)
            {

                var studentIds = context.ItemProgramStudents.Where(ips => ips.ItemProgram.ItemId == id).Select(ips => ips.StudentId).ToList();
                var oldIPS = context.ItemProgramStudents.Where(ips => studentIds.Contains(ips.StudentId)).ToList();
                context.ItemProgramStudents.RemoveRange(oldIPS);
                lecture.WorkHours = updatedLecture.WorkHours;
                await context.SaveChangesAsync();

                var students = await context.Students
                .Where(ips => studentIds.Contains(ips.Id))
                .Include(s => s.Selection)
                    .ThenInclude(s => s.Program)
                        .ThenInclude(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
                            .ThenInclude(ips => ips.Item)
                .ToListAsync();

                var ips = Calc.SetItemsStartEndDates(students);

                context.ItemProgramStudents.AddRange(ips);
            }
            lecture = mapper.Map(updatedLecture, lecture);

            lecture.ModifiedAt = DateTime.Now;

            await context.SaveChangesAsync();

            return mapper.Map<GetLectureDto>(lecture);
        }

        //public override async Task<List<GetLectureDto>> Delete(int id, string includes = "")
        //{
        //     delete and recalculate ips koji sadrze itemId == id
        //}


    }
}
