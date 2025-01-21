﻿namespace Practice_9
{
    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(string name, List<int> grades)
        {
            students.Add(new Student { Name = name, Grades = grades });
        }

        public IEnumerable<string> GetStudents()
        {
            return students.Select(s => $"{s.Name} - Средний балл: {Math.Round(s.Grades.Average())}");
        }

        public bool UpdateStudent(string name, List<int> newGrades)
        {
            var student = students.FirstOrDefault(s => s.Name == name);
            if (student == null) return false;
            student.Grades = newGrades;
            return true;
        }

        public bool RemoveStudent(string name)
        {
            var student = students.FirstOrDefault(s => s.Name == name);
            if (student == null) return false;
            students.Remove(student);
            return true;
        }
    }
}