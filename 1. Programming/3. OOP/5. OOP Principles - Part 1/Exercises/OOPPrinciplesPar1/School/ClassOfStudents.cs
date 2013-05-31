using System.Collections.Generic;

namespace School
{
    class ClassOfStudents : ICommentable
    {
        private string uniqueTextIdentifier;
        private List<Student> setOfStudents = new List<Student>();
        private List<Teacher> setOfTeachers = new List<Teacher>();
        private List<string> comments = new List<string>();

        public ClassOfStudents(string name)
        {
            this.uniqueTextIdentifier = name;
        }

        public ClassOfStudents(string name, string comment)
        {
            this.uniqueTextIdentifier = name;
            this.comments.Add(comment);
        }

        //add student
        public void AddStudent(Student student)
        {
            this.setOfStudents.Add(student);
        }

        //remove student
        public void RemoveDiscipline(Student student)
        {
            this.setOfStudents.Remove(student);
        }

        //clear student
        public void ClearDisciplines()
        {
            this.setOfStudents.Clear();
        }

        //get all student as a list
        public List<Student> GetStudents()
        {
            return this.setOfStudents;
        }

        //add teacher
        public void AddTeacher(Teacher teacher)
        {
            this.setOfTeachers.Add(teacher);
        }

        //remove teacher
        public void RemoveTeacher(Teacher teacher)
        {
            this.setOfTeachers.Remove(teacher);
        }

        //clear teacher
        public void ClearTeachers()
        {
            this.setOfTeachers.Clear();
        }

        //get all teacher as a list
        public List<Teacher> GetTeachers()
        {
            return this.setOfTeachers;
        }

        public List<string> Comments
        {
            get { return this.comments; }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
