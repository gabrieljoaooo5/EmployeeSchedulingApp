using EmployeeSchedulingApp.Parsers;

namespace EmployeeAppSchedulingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Employee_Constructor_Should_SetPropertiesCorrectly()
        {
            // Arrange
            string name = "John";
            List<TimeRange> schedule = new List<TimeRange>
            {
                new TimeRange(DayOfWeek.Monday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
                new TimeRange(DayOfWeek.Wednesday, new TimeSpan(10, 0, 0), new TimeSpan(16, 0, 0)),
                new TimeRange(DayOfWeek.Friday, new TimeSpan(14, 0, 0), new TimeSpan(18, 0, 0))
            };

            // Act
            Employee employee = new Employee(name, schedule);

            // Assert
            Assert.AreEqual(name, employee.Name);
            CollectionAssert.AreEqual(schedule, employee.Schedule);
        }

        [TestMethod]
        public void Parse_ValidInputFile_ReturnsListOfEmployeesWithSchedules()
        {
            // Arrange
            string filePath = "input.txt";
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string absoluteFilePath = Path.Combine(projectDirectory, filePath);
            ScheduleParser parser = new ScheduleParser();

            // Act
            List<Employee> employees = parser.Parse(absoluteFilePath);

            // Assert
            Assert.IsNotNull(employees);
            Assert.AreEqual(3, employees.Count);
        }

        [TestMethod]
        public void Test_CountCoincidences_ReturnsCorrectResult()
        {
            // Arrange
            Employee rene = new Employee("RENE", new List<TimeRange>()
            {
                new TimeRange(DayOfWeek.Monday, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0)),
                new TimeRange(DayOfWeek.Tuesday, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0)),
                new TimeRange(DayOfWeek.Thursday, new TimeSpan(1, 0, 0), new TimeSpan(3, 0, 0)),
                new TimeRange(DayOfWeek.Saturday, new TimeSpan(14, 0, 0), new TimeSpan(18, 0, 0)),
                new TimeRange(DayOfWeek.Sunday, new TimeSpan(20, 0, 0), new TimeSpan(21, 0, 0))
            });

            Employee astrid = new Employee("ASTRID", new List<TimeRange>()
            {
                new TimeRange(DayOfWeek.Monday, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0)),
                new TimeRange(DayOfWeek.Thursday, new TimeSpan(12, 0, 0), new TimeSpan(14, 0, 0)),
                new TimeRange(DayOfWeek.Sunday, new TimeSpan(20, 0, 0), new TimeSpan(21, 0, 0))
            });

            Employee andres = new Employee("ANDRES", new List<TimeRange>()
            {
                new TimeRange(DayOfWeek.Monday, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0)),
                new TimeRange(DayOfWeek.Thursday, new TimeSpan(12, 0, 0), new TimeSpan(14, 0, 0)),
                new TimeRange(DayOfWeek.Sunday, new TimeSpan(20, 0, 0), new TimeSpan(21, 0, 0))
            });

            // Act
            int astridReneCoincidences = ScheduleChecker.CountCoincidences(astrid, rene);
            int astridAndresCoincidences = ScheduleChecker.CountCoincidences(astrid, andres);
            int reneAndresCoincidences = ScheduleChecker.CountCoincidences(rene, andres);

            // Assert
            Assert.AreEqual(2, astridReneCoincidences);
            Assert.AreEqual(3, astridAndresCoincidences);
            Assert.AreEqual(2, reneAndresCoincidences);
        }
    }
}

