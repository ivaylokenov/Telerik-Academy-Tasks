using System;
using System.Threading;
using System.Globalization;

class NNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "N numbers";
        string title = new string('-', 50);
        Console.WriteLine(title);
        Console.WriteLine("This program gets 'n' numbers and prints their sum");
        Console.WriteLine(title + "\n\r");
        Console.Write("Enter positive number 'n': ");
        int numbersCount;
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out numbersCount);
        while ((numbersCount <= 0) || (parseSuccess == false))
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out numbersCount);
        }
        decimal number;
        decimal numberSum = 0;
        for (int i = 1; i <= numbersCount; i++)
        {
            Console.Write("Enter number {0}: ", i);
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr,out number);
            while (parseSuccess == false)
            {
                Console.Write("Your input for number {0} is invalid. Try again: ", i);
                readStr = Console.ReadLine();
                parseSuccess = decimal.TryParse(readStr, out number);
            }
            numberSum += number;
        }
        Console.Write("\n\rThe sum of all {0} numbers is: {1}.\n\r",numbersCount, numberSum);
    }
}
