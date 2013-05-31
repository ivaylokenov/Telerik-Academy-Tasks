using System;
using System.Globalization;
using System.Threading;

class ThreeNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Three numbers";
        string title = new string('-', 48);
        Console.WriteLine(title);
        Console.WriteLine("This program calculates the sum of three numbers");
        Console.WriteLine(title + "\n\r");
        Console.Write("Enter first number: ");
        string readStr = Console.ReadLine();
        decimal firstNumber;
        bool parseSuccess = decimal.TryParse(readStr, out firstNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out firstNumber);
        }
        Console.Write("Enter second number: ");
        readStr = Console.ReadLine();
        decimal secondNumber;
        parseSuccess = decimal.TryParse(readStr, out secondNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out secondNumber);
        }
        Console.Write("Enter third number: ");
        readStr = Console.ReadLine();
        decimal thirdNumber;
        parseSuccess = decimal.TryParse(readStr, out thirdNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out thirdNumber);
        }
        Console.WriteLine("\n\rThe sum of your numbers is: {0}.\n\r", (firstNumber + secondNumber + thirdNumber));
    }
}
