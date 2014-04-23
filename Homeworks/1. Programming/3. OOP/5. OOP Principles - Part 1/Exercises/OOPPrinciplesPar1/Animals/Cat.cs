namespace Animals
{
    abstract class Cat : Animal
    {
        public override void ProduceSound()
        {
            System.Console.WriteLine("Miau!");
        }
    }
}
