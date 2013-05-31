using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        string title = new string('-', 36);
        Console.Title = "Catalan Number";
        Console.WriteLine(title);
        Console.WriteLine("This program prints Catalan Number N");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        string readStr;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter number N >= 0: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 0);

        decimal catalan = 1;

        for (decimal i = (number + 2), j = number; i <= 2 * number; i++, j--)
        {
            catalan *= (i / j);
        }

        Console.WriteLine("\n\rCatalan Number {1}: {0:0}.\n\r", catalan, number);
    }
}
