using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeSchedulingApp.Parsers
{
    public class ScheduleParser
    {
        public List<Employee> Parse(string filePath)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    string name = parts[0].Trim();
                    string[] schedules = parts[1].Split(',');

                    List<TimeRange> timeRanges = new List<TimeRange>();
                    foreach (string schedule in schedules)
                    {
                        string[] scheduleParts = schedule.Split('-');
                        string dayOfWeek = scheduleParts[0].Substring(0, 2).ToUpper();
                        TimeSpan startTime = TimeSpan.Parse(scheduleParts[0].Substring(2));
                        TimeSpan endTime = TimeSpan.Parse(scheduleParts[1]);
                        timeRanges.Add(new TimeRange(ParseDayOfWeek(dayOfWeek), startTime, endTime));
                    }

                    employees.Add(new Employee(name, timeRanges));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing input file: " + ex.Message);
            }

            return employees;
        }

        private static DayOfWeek ParseDayOfWeek(string dayOfWeekString)
        {
            switch (dayOfWeekString.ToUpper())
            {
                case "MO":
                    return DayOfWeek.Monday;
                case "TU":
                    return DayOfWeek.Tuesday;
                case "WE":
                    return DayOfWeek.Wednesday;
                case "TH":
                    return DayOfWeek.Thursday;
                case "FR":
                    return DayOfWeek.Friday;
                case "SA":
                    return DayOfWeek.Saturday;
                case "SU":
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentException($"Invalid day of week string: {dayOfWeekString}");
            }
        }
    }
}
