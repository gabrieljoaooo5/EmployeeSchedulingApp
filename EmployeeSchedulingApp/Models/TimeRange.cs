public class TimeRange
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public TimeRange(DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime)
    {
        if (startTime > endTime)
        {
            throw new ArgumentException("Start time cannot be greater than end time.");
        }
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
    }
}