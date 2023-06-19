using JapPlatformBackend.Common.Enums;
using JapPlatformBackend.Core.Entities;
using JapPlatformBackend.Core.Entities.Base;
using JapPlatformBackend.Database;
using JapPlatformBackend.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace JapPlatformBackend.Repositories
{
    [TestFixture]
    public class CalcTests
    {
        private static DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TempJapPlatform")
                .Options;

        DataContext context;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new DataContext(options);

            SeedDatabase();

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public async Task SetItemsStartEndDates_InputIncompleteStudentsList_NullReferenceException()
        {
            //arrange
            var students = await context.Students.Where(s => s.Id == 1).ToListAsync();

            //act
            var exceptionDetails = Assert.Throws<NullReferenceException>(() => Calc.SetItemsStartEndDates(students));

            //assert
            Assert.IsNotNull(exceptionDetails);
            Assert.AreEqual("Object reference not set to an instance of an object.", exceptionDetails.Message);
        }

        [Test]
        public void SetItemsStartEndDates_InputEmptyStudentsList_GetEmptyList()
        {
            //arrange
            var students = new List<Student>();

            //act
            var result = Calc.SetItemsStartEndDates(students);

            //assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task SetItemsStartEndDates_InputStudentsList_GetIPSListWithValidDates()
        {
            //arrange
            var students = await context.Students
                .Where(s => s.Id != 1)
                .Include(s => s.Selection)
                    .ThenInclude(s => s.Program)
                        .ThenInclude(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
                            .ThenInclude(ips => ips.Item)
                .ToListAsync();
            var selectionStart = new DateTime(2022, 09, 05);

            //act
            var result = Calc.SetItemsStartEndDates(students);

            //assert
            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(selectionStart, result[0].StartDate);
            Assert.AreEqual(selectionStart.AddDays(1), result[0].EndDate);
            Assert.AreEqual(selectionStart.AddDays(1), result[1].StartDate);
            Assert.AreEqual(selectionStart.AddDays(3), result[1].EndDate);
        }

        [Test]
        public async Task SetItemsStartEndDates_InputStudentsListOneStudent_GetIPSListWithValidDates()
        {
            //arrange
            var students = await context.Students
                .Where(s => s.Id == 2)
                .Include(s => s.Selection)
                    .ThenInclude(s => s.Program)
                        .ThenInclude(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
                            .ThenInclude(ips => ips.Item)
                .ToListAsync();
            var selectionStart = new DateTime(2022, 09, 05);

            //act
            var result = Calc.SetItemsStartEndDates(students);

            //assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(selectionStart, result[0].StartDate);
            Assert.AreEqual(selectionStart.AddDays(1), result[0].EndDate);
        }

        private void SeedDatabase()
        {
            List<Student> students = new(){
                new Student
                {
                    Id = 1,
                    UserName = "jack",
                    PasswordHash = "string",
                    Email = "mail@mail.com",
                },
                new Student
                {
                    Id = 2,
                    UserName = "john",
                    PasswordHash = "string",
                    Email = "mail@mail.com",
                    SelectionId = 1
                },
                new Student
                {
                    Id = 3,
                    UserName = "jane",
                    PasswordHash = "string",
                    Email = "mail@mail.com",
                    SelectionId = 1
                },
                new Student
                {
                    Id = 4,
                    UserName = "jessica",
                    PasswordHash =  "string",
                    Email = "mail@mail.com",
                    SelectionId = 1
                } };

            var program = new Program
            {
                Id = 1,
                Name = "JAP Dev",
                Description = "Dev JAP Description"
            };

            var selection = new Selection
            {
                Id = 1,
                Name = "JAP Dev 09/2022",
                StartDate = new DateTime(2022, 09, 05),
                EndDate = new DateTime(2022, 10, 23),
                Status = SelectionStatus.Active,
                ProgramId = 1
            };

            var ip1 = new ItemProgram()
            {
                ItemId = 1,
                Item = new Item { Id = 1, Name = "Item1", WorkHours = 8 },
                ProgramId = 1,
                OrderNumber = 1
            };

            var ip2 = new ItemProgram()
            {
                ItemId = 2,
                Item = new Item { Id = 2, Name = "Item2", WorkHours = 16 },
                ProgramId = 1,
                OrderNumber = 2,
            };

            context.Programs.Add(program);
            context.Selections.Add(selection);
            context.Students.AddRange(students);
            context.ItemPrograms.AddRange(ip1, ip2);

            context.SaveChanges();
        }
    }
}
