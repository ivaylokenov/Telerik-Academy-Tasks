namespace Animals
{
    abstract class Animal : ISound
    {
        private string name;
        private string sex;
        private int age;

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string Sex
        {
            get { return this.sex; }
            protected set
            {
                if (value != "male" && value != "female")
                {
                    throw new System.ArgumentException("Sex can be male or female");
                }

                this.sex = value; 
            }
        }

        public int Age
        {
            get { return this.age; }
            protected set 
            {
                if (value < 0)
                {
                    throw new System.ArgumentException("Age cannot be less than zero!");
                }

                this.age = value; 
            }
        }

        public abstract void ProduceSound();
    }
}
