namespace School
{
    class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
    }
}
