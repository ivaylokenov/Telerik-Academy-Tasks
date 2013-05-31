using System.Collections.Generic;

namespace School
{
    class Teacher : Person, ICommentable
    {
        private List<Discipline> setOfDisciplines = new List<Discipline>();
        private List<string> comments = new List<string>();

        public Teacher(string name)
            : base(name)
        {
        }

        public Teacher(string name, string comment)
            : base(name)
        {
            this.comments.Add(comment);
        }

        //add discplines to the teacher
        public void AddDiscipline(Discipline discipline)
        {
            this.setOfDisciplines.Add(discipline);
        }

        //remove disciplines to the teacher
        public void RemoveDiscipline(Discipline discipline)
        {
            this.setOfDisciplines.Remove(discipline);
        }

        //clear all diciplines
        public void ClearDisciplines()
        {
            this.setOfDisciplines.Clear();
        }

        //get all disciplines as a list
        public List<Discipline> GetDisciplines()
        {
            return this.setOfDisciplines;
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
