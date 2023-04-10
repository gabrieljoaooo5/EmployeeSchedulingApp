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
    }
}

