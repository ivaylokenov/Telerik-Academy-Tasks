using System.Collections.Generic;

namespace School
{
    class Student : Person, ICommentable
    {
        private readonly int uniqueClassNumber;
        private List<string> comments = new List<string>();

        public Student(string name, int number)
            : base(name)
        {
            this.uniqueClassNumber = number;
        }

        public Student(string name, int number, string comment)
            : base(name)
        {
            this.uniqueClassNumber = number;
            this.comments.Add(comment);
        }

        public int UniqueClassNumber
        {
            get { return this.uniqueClassNumber; }
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
