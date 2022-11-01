using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                Employee employee = new Employee(arr[0], decimal.Parse(arr[1]), arr[2]);

                employees.Add(employee);
            }


            decimal average = decimal.MinValue;
            decimal averageDep = decimal.MinValue;
            string department = "";
            foreach (var item in employees)
            {

                if (item.Department == department)
                {
                    average += item.Salary;
                    averageDep += item.Salary;
                }
                else if (item.Salary > average)
                {


                    average = item.Salary;
                    department = item.Department;

                }

            }
            Console.WriteLine($"Highest Average Salary: {department}");
            foreach (var item in employees.Where(x => x.Department == department).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{item.Name} {item.Salary:f2}");
            }

        }
    }
    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
