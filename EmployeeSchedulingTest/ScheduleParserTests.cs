using EmployeeSchedulingApp.Parsers;

namespace EmployeeAppSchedulingTest
{
    [TestClass]
    public class ScheduleParserTests
    {
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
        [ExpectedException(typeof(Exception))]
        public void Parse_Should_ThrowException_When_InvalidInputFileProvided()
        {
            // Arrange
            string filePath = "invalid_input.txt"; 
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string absoluteFilePath = Path.Combine(projectDirectory, filePath);
            ScheduleParser parser = new ScheduleParser();

            // Act 
            List<Employee> employees = parser.Parse(absoluteFilePath);

            // Assert
            // Exception is expected to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Parse_Should_ThrowException_When_InvalidDayOfWeekStringProvided()
        {
            // Arrange
            string filePath = "invalid_dayofweek_input.txt";
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            string absoluteFilePath = Path.Combine(projectDirectory, filePath);
            ScheduleParser parser = new ScheduleParser();

            // Act
            List<Employee> employees = parser.Parse(absoluteFilePath);

            // Assert
            // Exception is expected to be thrown
        }
    }
}

