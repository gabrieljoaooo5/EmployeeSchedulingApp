using System;
using System.Collections.Generic;
using System.Text;
//using EmployeeSchedulingApp.Models;
using EmployeeSchedulingApp.Parsers;

namespace EmployeeSchedulingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath1 = "example1.txt";
            string filePath2 = "example2.txt";
            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            
            string absoluteFilePath1 = Path.Combine(projectDirectory, filePath1);
            string absoluteFilePath2 = Path.Combine(projectDirectory, filePath2);
            
            ScheduleParser parser = new ScheduleParser();
            List<Employee> employeesExample1 = parser.Parse(absoluteFilePath1);
            List<Employee> employeesExample2 = parser.Parse(absoluteFilePath2);

            Console.WriteLine("Example 1:");
            PrintCoincidences(employeesExample1);

            Console.WriteLine("Example 2:");
            PrintCoincidences(employeesExample2);
        }

        public static void PrintCoincidences(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = i + 1; j < employees.Count; j++)
                {
                    int coincidences = ScheduleChecker.CountCoincidences(employees[i], employees[j]);
                    Console.WriteLine($"{employees[i].Name}-{employees[j].Name}:{coincidences}");
                }
            }
        }
    }
}
