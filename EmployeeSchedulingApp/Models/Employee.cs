public class Employee
{
    public string Name { get; set; }
    public List<TimeRange> Schedule { get; set; }

    public Employee(string name, List<TimeRange> schedule)
    {
        Name = name;
        Schedule = schedule;
    }
}
