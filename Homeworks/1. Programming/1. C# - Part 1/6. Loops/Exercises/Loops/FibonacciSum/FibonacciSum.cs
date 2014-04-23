using System;
using System.Numerics;

class FibonacciSum
{
    static void Main()
    {
        string title = new string('-', 60);
        Console.Title = "Print sum of Fibonacci";
        Console.WriteLine(title);
        Console.WriteLine("This program calculates the sum of first N Fibonacci numbers");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        string readStr;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter positive number N > 1: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 2);

        BigInteger firstNumber = 1;
        BigInteger secondNumber = 1;
        BigInteger thirdNumber;
        BigInteger sum = 2;

        for (int i = 3; i <= number; i++)
        {
            thirdNumber = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = thirdNumber;
            sum += thirdNumber;
        }

        Console.WriteLine("\n\rSum of first {0} Fibonacci numbers is: {1}.\n\r", number, sum);
    }
}
