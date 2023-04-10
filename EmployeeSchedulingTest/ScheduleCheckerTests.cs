namespace EmployeeAppSchedulingTest
{
    [TestClass]
    public class ScheduleCheckerTests
    {
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

        [TestMethod]
        public void Test_CountCoincidences_ReturnsZero_WhenNoCoincidences()
        {
            // Arrange
            Employee john = new Employee("JOHN", new List<TimeRange>()
            {
                new TimeRange(DayOfWeek.Monday, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0)),
                new TimeRange(DayOfWeek.Wednesday, new TimeSpan(14, 0, 0), new TimeSpan(16, 0, 0)),
                new TimeRange(DayOfWeek.Friday, new TimeSpan(9, 0, 0), new TimeSpan(11, 0, 0))
            });

            Employee jane = new Employee("JANE", new List<TimeRange>()
            {
                new TimeRange(DayOfWeek.Tuesday, new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0)),
                new TimeRange(DayOfWeek.Thursday, new TimeSpan(12, 0, 0), new TimeSpan(14, 0, 0)),
                new TimeRange(DayOfWeek.Saturday, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0))
            });

            // Act
            int johnJaneCoincidences = ScheduleChecker.CountCoincidences(john, jane);

            // Assert
            Assert.AreEqual(0, johnJaneCoincidences);
        }
    }
}

