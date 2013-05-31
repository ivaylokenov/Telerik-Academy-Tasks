using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class Test
    {
        static decimal AverageAge(Animal[] animals)
        {
            decimal sumOfAges = 0;

            foreach (var animal in animals)
            {
                sumOfAges += animal.Age;
            }

            decimal averageAge = sumOfAges / animals.Length;

            return averageAge;
        }

        static void Main()
        {
            Dog[] dogs = 
            {
                new Dog("Sharo", "male", 5),
                new Dog("Kiro", "male", 2),
                new Dog("Minka", "female", 4)
            };

            Frog[] frogs = 
            {
                new Frog("Zelencho", "male", 2),
                new Frog("Chervencho", "male", 8),
                new Frog("Jyltichka", "female", 5),
                new Frog("Belka", "female", 4)
            };

            Cat[] cats = 
            {
                new Kitten("Penda", 8),
                new Tomcat("Pijo", 3)
            };

            Console.WriteLine("Average age of dogs: " + AverageAge(dogs));
            Console.WriteLine("Average age of frogs: " + AverageAge(frogs));
            Console.WriteLine("Average age of cats: " + AverageAge(cats));
        }
    }
}
