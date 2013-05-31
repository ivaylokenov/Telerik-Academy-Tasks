using System;
using System.Globalization;
using System.Threading;

class NumbersP
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "FIVE";
        string title = new string('-', 69);
        Console.WriteLine(title);
        Console.WriteLine("Numbers between two integers to have remainder 0 of the division by 5");
        Console.WriteLine(title + "\n\r");
        uint firstNumber;
        uint secondNumber;
        Console.Write("Enter first positive number: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = UInt32.TryParse(readStr, out firstNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = UInt32.TryParse(readStr, out firstNumber);
        }
        Console.Write("Enter second positive number: ");
        readStr = Console.ReadLine();
        parseSuccess = UInt32.TryParse(readStr, out secondNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = UInt32.TryParse(readStr, out secondNumber);
        }
        int sumOfNumbers = 0;
        for (uint i = firstNumber; i <= secondNumber; i++)
        {
            if ((i % 5) == 0)
            {
                sumOfNumbers += 1;
            }
        }
        Console.WriteLine("\n\r{0} numbers.\n\r", sumOfNumbers);
    }
}
