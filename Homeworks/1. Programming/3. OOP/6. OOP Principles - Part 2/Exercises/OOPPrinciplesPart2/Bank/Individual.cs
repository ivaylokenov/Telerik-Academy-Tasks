namespace Bank
{
    class Individual : Customer
    {
        private int age;
        private string sex;

        public int Age
        {
            get { return this.age; }
            set
            {
                CheckAge(value);
                this.age = value;
            }
        }

        public string Sex
        {
            get { return this.sex; }
            set
            {
                CheckSex(value);
                this.sex = value;
            }
        }

        public Individual(string name, int age, string sex)
        {
            CheckAge(age);
            CheckSex(sex);

            this.name = name;
            this.age = age;
            this.sex = sex;
        }

        //method for age checking
        private void CheckAge(int age)
        {
            if (age < 0 || age > 150)
            {
                throw new System.ArgumentException("Age is invalid. Should be > 0 && < 150");
            }
        }

        //method for sex checking
        private void CheckSex(string sex)
        {
            if (sex != "Male" && sex != "Female")
            {
                throw new System.ArgumentException("Sex is invalid. Should be Male or Female!");
            }
        }
    }
}
