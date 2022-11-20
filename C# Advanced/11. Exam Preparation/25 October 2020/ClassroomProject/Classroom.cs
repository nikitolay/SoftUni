using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private ICollection<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToRemove = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            if (!students.Any(x => x.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in students.Where(x => x.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString();
        }
        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
