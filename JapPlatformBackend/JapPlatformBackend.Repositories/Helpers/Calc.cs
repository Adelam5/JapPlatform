using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Repositories.Helpers
{
    public static class Calc
    {
        public static async Task<List<Student>> PrepareStudent(DataContext context, int studentId)
        {
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

            return students;
        }

        public static async Task<List<Student>> PrepareStudents(DataContext context, Program program)
        {
            var oldIPS = program.ItemPrograms
                .Select(ip => ip.ItemProgramStudents)
                .SelectMany(ips => ips).ToList();

            context.ItemProgramStudents.RemoveRange(oldIPS);
            await context.SaveChangesAsync();

            var students = program.Selections.Select(s => s.Students).SelectMany(s => s).ToList();

            return students;
        }
        public static List<ItemProgramStudent> SetItemsStartEndDates(List<Student> students)
        {
            var ips = new List<ItemProgramStudent>();

            foreach (var student in students)
            {
                for (int i = 0; i < student.Selection.Program.ItemPrograms.Count; i++)
                {
                    var duration = Math.Ceiling((double)student.Selection.Program.ItemPrograms[i]
                        .Item.WorkHours / 8);

                    var startDate = i == 0
                        ? student.Selection.StartDate
                        : ips.Last().EndDate;

                    var endDate = i == 0
                        ? student.Selection.StartDate.AddDays(duration)
                        : startDate?.AddDays(duration);

                    ips.Add(new ItemProgramStudent
                    {
                        ItemProgramId = student.Selection.Program.ItemPrograms[i].Id,
                        StudentId = student.Id,
                        StartDate = startDate,
                        EndDate = endDate,

                    });
                }
            }

            return ips;
        }
    }
}
