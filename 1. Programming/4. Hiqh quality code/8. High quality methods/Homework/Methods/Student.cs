namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthYear { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            if (this.BirthYear == null || other.BirthYear == null)
            {
                throw new ArgumentNullException("Age is not set in both students!");
            }

            return this.BirthYear < other.BirthYear;
        }
    }
}
