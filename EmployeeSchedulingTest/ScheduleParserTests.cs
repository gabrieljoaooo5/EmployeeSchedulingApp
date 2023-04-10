using EmployeeSchedulingApp.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace EmployeeAppSchedulingTest
{
    [TestClass]
    public class ScheduleParserTests
    {
        private ScheduleParser parser;

        [TestInitialize]
        public void Initialize()
        {
            parser = new ScheduleParser();
        }

        [TestMethod]
        public void Parse_ValidInputFile_ReturnsListOfEmployeesWithSchedules()
        {
            // Arrange
            string filePath = "input.txt";
            string absoluteFilePath = Path.Combine(GetProjectDirectory(), "samples", filePath);

            // Act
            var employees = parser.Parse(absoluteFilePath);

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
            string absoluteFilePath = Path.Combine(GetProjectDirectory(), "samples", filePath);

            // Act 
            var employees = parser.Parse(absoluteFilePath);

            // Assert
            // Exception is expected to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void Parse_Should_ThrowException_When_InvalidDayOfWeekStringProvided()
        {
            // Arrange
            string filePath = "invalid_dayofweek_input.txt";
            string absoluteFilePath = Path.Combine(GetProjectDirectory(), "samples", filePath);

            // Act
            var employees = parser.Parse(absoluteFilePath);

            // Assert
            // Exception is expected to be thrown
        }

        private string GetProjectDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            return projectDirectory;
        }
    }
}
