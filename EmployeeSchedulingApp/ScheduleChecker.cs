public static class ScheduleChecker
{
    public static int CountCoincidences(Employee employee1, Employee employee2)
    {
        int coincidences = 0;

        foreach (var timeRange1 in employee1.Schedule)
        {
            foreach (var timeRange2 in employee2.Schedule)
            {
                if (timeRange1.DayOfWeek == timeRange2.DayOfWeek &&
                    CheckTimeRangeCoincidence(timeRange1, timeRange2))
                {
                    coincidences++;
                }
            }
        }

        return coincidences;
    }

    private static bool CheckTimeRangeCoincidence(TimeRange timeRange1, TimeRange timeRange2)
    {
        if (timeRange1.EndTime <= timeRange2.StartTime || timeRange1.StartTime >= timeRange2.EndTime)
        {
            return false;
        }

        return true;
    }
}
