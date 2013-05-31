using System;
using System.Globalization;
using System.Threading;

class GreaterValue
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Greater value";
        string title = new string('-', 48);
        Console.WriteLine(title);
        Console.WriteLine("This program finds the greater integer among two");
        Console.WriteLine(title);
        int[] numbers = new int[2];
        Console.Write("\n\rEnter two integers: ");
        string readStr = Console.ReadLine();
        string[] separatedRead = readStr.Split(' ');
        while (separatedRead.Length != 2)
        {
            Console.WriteLine("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            separatedRead = readStr.Split(' ');
        }
        for (int i = 0; i < separatedRead.Length; i++)
        {
            bool parseSuccess = int.TryParse(separatedRead[i], out numbers[i]);
            while (parseSuccess == false)
            {
                Console.WriteLine("Your input is not valid. Try again: ");
                readStr = Console.ReadLine();
                separatedRead = readStr.Split(' ');
                parseSuccess = int.TryParse(separatedRead[i], out numbers[i]);
                i = 0;
            }
        }
        int biggerNumber;
        if (numbers[1] > numbers[0])
        {
            biggerNumber = numbers[1];
        }
        else
        {
            biggerNumber = numbers[0];
        }
        Console.WriteLine("\n\rThe bigger number is: {0}.\n\r", biggerNumber);
    }
}
