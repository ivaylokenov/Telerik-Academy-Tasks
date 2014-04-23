namespace Humans
{
    class Student : Human
    {
        private readonly decimal grade;

        public Student(string firstName, string lastName, decimal grade)
        {
            if (grade < 2 && grade > 6)
            {
                throw new System.ArgumentException("Grade can be between 2 and 6!");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.grade = grade;
        }

        public decimal Grade
        {
            get { return this.grade; }
        }
    }
}
