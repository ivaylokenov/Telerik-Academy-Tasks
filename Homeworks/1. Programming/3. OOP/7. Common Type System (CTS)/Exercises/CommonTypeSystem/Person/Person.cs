namespace Person
{
    class Person
    {
        //properties
        public string Name { get; set; }
        public int? Age { get; set; }

        //constructor
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            if (Age == null)
            {
                return string.Format("Person\n\rName: {0}\n\rAge: {1}", this.Name, "Not specified");
            }
            else
            {
                return string.Format("Person\n\rName: {0}\n\rAge: {1}", this.Name, this.Age);
            }
        }
    }
}
