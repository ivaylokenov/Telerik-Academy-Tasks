using System.Collections.Generic;

namespace School
{
    class Discipline : ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private List<string> comments = new List<string>();

        public Discipline(string name, int lectures, int exercises)
        {
            this.name = name;
            this.numberOfLectures = lectures;
            this.numberOfExercises = exercises;
        }

        public Discipline(string name, int lectures, int exercises, string comment)
        {
            this.name = name;
            this.numberOfLectures = lectures;
            this.numberOfExercises = exercises;
            this.comments.Add(comment);
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Lectures
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }

        public int Exercises
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
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
