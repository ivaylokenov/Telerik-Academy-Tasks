using System;

class IsPrime
{
    static void Main()
    {
        int number;
        Console.Write("Enter number between 0 and 100: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out number);
        while (number < 0 || number > 100 || parseSuccess == false)
        {
            Console.Write("Your number is not valid. It should be > 0 and < 100 Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out number);
        }
        bool isPrime = true;
        if (number == 1)
        {
            isPrime = false;
        }
        for (int i = 2; i < number; i++)
        {
            if ((number % i) == 0)
            {
                isPrime = false;
            }
        }
        if (isPrime == true)
        {
            Console.WriteLine("Your number is prime.");
        }
        else
        {
            Console.WriteLine("Your number is not prime.");
        }
    }
}
