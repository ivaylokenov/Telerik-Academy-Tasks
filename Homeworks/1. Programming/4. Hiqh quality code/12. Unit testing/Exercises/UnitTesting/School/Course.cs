namespace SchoolClassLibrary
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private readonly List<Student> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null.");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Count >= 30)
            {
                throw new ArgumentOutOfRangeException("Students in course should be less than 30.");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.Contains(student))
            {
                throw new ArgumentException("Student is not in the course list.");
            }

            this.students.Remove(student);
        }
    }
}
