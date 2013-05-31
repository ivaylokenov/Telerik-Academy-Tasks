namespace SchoolClassLibrary
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private readonly Dictionary<Student, int> students;
        private readonly List<Course> courses;
        private int countID;

        public School()
        {
            this.students = new Dictionary<Student, int>();
            this.courses = new List<Course>();
            countID = 10000;
        }

        public Dictionary<Student, int> Students
        {
            get
            {
                return this.students;
            }
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.ContainsKey(student))
            {
                throw new ArgumentException("Student already exists in the school.");
            }

            // check if all student numbers already exists in school
            if (this.students.Count >= 90000)
            {
                throw new ArgumentException("School is full and have its maximum capacity.");
            }

            int number = 10000;

            for (int i = 10000; i <= countID + 1; i++)
            {
                if (this.students.ContainsValue(i))
                {
                    continue;
                }
                else
                {
                    number = i;

                    if (countID < number)
                    {
                        countID = number;
                    }

                    break;
                }
            }

            this.students.Add(student, number);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.ContainsKey(student))
            {
                throw new ArgumentException("Student was not found in this school.");
            }

            this.students.Remove(student);

            // remove the student from all courses in the school which he atends
            for (int i = 0; i < this.courses.Count; i++)
            {
                try
                {
                    this.courses[i].RemoveStudent(student);
                }
                catch
                {
                    continue;
                }
            }
        }

        public int? GetID(Student student)
        {
            if (!this.students.ContainsKey(student))
            {
                throw new ArgumentException("Student was not found in this school.");
            }

            return this.students[student];
        }

        public void AddCourse(Course course)
        {
            if (this.courses.Contains(course))
            {
                throw new ArgumentException("Course already exists in the school.");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("Course was not found in this course.");
            }

            this.courses.Remove(course);
        }
    }
}
