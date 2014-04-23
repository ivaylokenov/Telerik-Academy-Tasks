using System;

namespace Person
{
    class Test
    {
        static void Main()
        {
            Person first = new Person("Beliq");
            Console.WriteLine(first.ToString());
            Person second = new Person("Choveka", 18);
            Console.WriteLine(second.ToString());
        }
    }
}
