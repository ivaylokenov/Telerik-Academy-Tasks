using System;
using System.Numerics;

class NKFactorialPart1
{
    static void Main()
    {
        string title = new string('-', 29);
        Console.Title = "N!/K!";
        Console.WriteLine(title);
        Console.WriteLine("This program calculates N!/K!");
        Console.WriteLine(title + "\n\r");
        int numberK = 0;
        int numberN = 0;
        string readStr;
        bool parseSuccess = false;

        do
        {
            Console.Write("Enter positive number K: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out numberK);
        }
        while (parseSuccess == false || numberK < 1);

        do
        {
            Console.Write("Enter positive number N > K: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out numberN);
        }
        while (parseSuccess == false || numberN < numberK);

        BigInteger result = 1;

        for (int i = numberK + 1; i <= numberN; i++)
        {
            result *= i;
        }

        Console.WriteLine("\n\rN! / K! = {0}.\n\r", result);
    }
}
