public class Employee
{
    public string Name { get; set; }
    public List<TimeRange> Schedule { get; set; }

    public Employee(string name)
    {
        Name = name;
        Schedule = new List<TimeRange>();
    }
}
