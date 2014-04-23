using System;
using System.Threading;
using System.Globalization;

class Print1toN
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "N numbers";
        string title = new string('-', 41);
        Console.WriteLine(title);
        Console.WriteLine("This program prints numbers from 0 to 'n'");
        Console.WriteLine(title + "\n\r");
        Console.Write("Enter positive number 'n': ");
        int number;
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out number);
        while ((number <= 0) || (parseSuccess == false))
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out number);
        }
        Console.Write("\n\r");
        for (int i = 1; i <= number; i++)
        {
            System.Threading.Thread.Sleep(200);
            Console.WriteLine(i);
        }
        Console.Write("\n\r");
    }
}
