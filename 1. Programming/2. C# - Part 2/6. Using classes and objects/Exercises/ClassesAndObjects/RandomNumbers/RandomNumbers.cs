using System;

class RandomNumbers
{
    static void Main()
    {
        Random randomNumber = new Random();
        for (int i = 1; i <= 10; i++)
        {
            int number = randomNumber.Next(100) + 100;
            Console.WriteLine(number);
        }
    }
}
