using System.Collections.Generic;

namespace School
{
    class School
    {
        private string name;
        private List<ClassOfStudents> classes = new List<ClassOfStudents>();

        public School(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        //add class
        public void AddClass(ClassOfStudents @class)
        {
            this.classes.Add(@class);
        }

        //remove class
        public void RemoveClass(ClassOfStudents @class)
        {
            this.classes.Remove(@class);
        }

        //clear classes
        public void ClearClass()
        {
            this.classes.Clear();
        }

        //get all classes as a list
        public List<ClassOfStudents> GetClasses()
        {
            return this.classes;
        }
    }
}
