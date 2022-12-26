using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            Console.WriteLine(RemoveTown(db));
        }

        //ex.3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                Id = x.EmployeeId,
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary
            }).OrderBy(x => x.Id).ToList();

            StringBuilder result = new StringBuilder();
            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }
            return result.ToString().TrimEnd();
        }

        //ex.4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {

            var emplpyees = context.Employees.Where(x => x.Salary > 50000).Select(x => new
            {
                x.FirstName,
                x.Salary
            }).OrderBy(x => x.FirstName).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var e in emplpyees)
            {
                result.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //ex.5

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department.Name,
                    x.Salary

                }).OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName).ToList();
            StringBuilder result = new StringBuilder();
            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - {e.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //ex.6

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Addresses
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            var employeeNakov = context.Employees
                .First(x => x.LastName == "Nakov");

            employeeNakov.Address = address;
            context.SaveChanges();

            var addresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var a in addresses)
            {
                result.AppendLine(a);
            }

            return result.ToString().TrimEnd();
        }

        //ex.7  
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Where(x => x.EmployeesProjects
            .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year < 2003))
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                .Select(x => new
                {
                    ProjectName = x.Project.Name,
                    StartDate = x.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    EndDate = x.Project.EndDate.HasValue ? x.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                }).ToList()

            }).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    result.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");

                }
            }
            return result.ToString().TrimEnd();
        }

        //ex.8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(x => new
                {
                    x.AddressText,
                    TownName = x.Town.Name,
                    EmployeesCount = x.Employees.Count
                })
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var a in addresses)
            {
                result.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return result.ToString().TrimEnd();
        }

        //ex.9

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    EmployeesProjects = x.EmployeesProjects.
                      OrderBy(x => x.Project.Name)
                      .Select(x => x.Project.Name)
                }).First(x => x.EmployeeId == 147);
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            result.AppendLine($"{string.Join(Environment.NewLine, employee.EmployeesProjects)}");

            return result.ToString().TrimEnd();

        }

        //ex.10

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees
                    .Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle
                    }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList()
                }).ToList();

            StringBuilder result = new StringBuilder();
            foreach (var d in departments)
            {

                result.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }

        //ex.11

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                }).OrderBy(x => x.Name).ToList();

            StringBuilder result = new StringBuilder();

            foreach (var p in projects)
            {
                result.AppendLine(p.Name)
                    .AppendLine(p.Description)
                    .AppendLine(p.StartDate);
            }

            return result.ToString().TrimEnd();
        }

        //ex.12

        public static string IncreaseSalaries(SoftUniContext context)
        {

            List<string> departmentNames = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employeesToIncreaseSalaries = context.Employees
                .Where(x => departmentNames.Contains(x.Department.Name));

            foreach (var e in employeesToIncreaseSalaries)
            {
                e.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = employeesToIncreaseSalaries
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Salary
                }).OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        //ex.13

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                }).OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();
            StringBuilder result = new StringBuilder();

            foreach (var e in employees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return result.ToString().TrimEnd();
        }

        //ex.14

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDelete = context.Projects.Find(2);


            context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList()
                .ForEach(x => context.EmployeesProjects.Remove(x));

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            StringBuilder result = new StringBuilder();

            context.Projects
                .Take(10)
                .Select(x => x.Name)
                .ToList()
                .ForEach(x => result.AppendLine(x));

            return result.ToString().TrimEnd();
        }

        //ex.15

        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context.Towns.First(x => x.Name == "Seattle");

            var addressesToDelete = context.Addresses.Where(x => x.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            var employeesOnDeleteAddress = context.Employees
                .Where(x => addressesToDelete.Any(y => y.AddressId == x.AddressId));

            foreach (var e in employeesOnDeleteAddress)
            {
                e.AddressId = null;
            }


            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{addressesCount} addresses in {townToDelete.Name} were deleted";
        }
    }
}
