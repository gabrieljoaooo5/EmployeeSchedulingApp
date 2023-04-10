namespace EmployeeAppSchedulingTest
{
    [TestClass]
    public class EmployeeTests
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
        [ExpectedException(typeof(ArgumentException))]
        public void TimeRange_Constructor_Should_ThrowException_When_StartTime_GreaterThan_EndTime()
        {
            // Arrange
            DayOfWeek dayOfWeek = DayOfWeek.Monday;
            TimeSpan startTime = new TimeSpan(10, 0, 0);
            TimeSpan endTime = new TimeSpan(9, 0, 0); 

            // Act
            TimeRange timeRange = new TimeRange(dayOfWeek, startTime, endTime);

            // Assert
            // Exception is expected to be thrown
        }
    }
}

