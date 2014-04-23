using System;
using System.Threading;
using System.Globalization;

class GreaterNumber
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Greater value";
        string title = new string('-', 57);
        Console.WriteLine(title);
        Console.WriteLine("This program finds the greater value between two integers");
        Console.WriteLine(title + "\n\r");
        decimal firstNumber;
        decimal secondNumber;
        Console.Write("Enter first number: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = decimal.TryParse(readStr, out firstNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out firstNumber);
        }
        Console.Write("Enter second number: ");
        readStr = Console.ReadLine();
        parseSuccess = decimal.TryParse(readStr, out secondNumber);
        while (parseSuccess == false)
        {
            Console.Write("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out secondNumber);
        }
        decimal greaterValue = Math.Max(firstNumber, secondNumber);
        Console.WriteLine("{0:F2} has greater value.", greaterValue);
    }
}
