namespace SchoolClassLibrary
{
    using System;

    public class Student
    {
        private string name;

        public Student(string name)
        {
            this.Name = name;
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
    }
}
