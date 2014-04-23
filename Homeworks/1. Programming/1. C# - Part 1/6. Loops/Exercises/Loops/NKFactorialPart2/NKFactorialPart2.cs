using System;
using System.Numerics;

class NKFactorialPart2
{
    static void Main()
    {
        string title = new string('-', 36);
        Console.Title = "N!*K!/(K-N)!";
        Console.WriteLine(title);
        Console.WriteLine("This program calculates N!*K!/(K-N)!");
        Console.WriteLine(title + "\n\r");
        int numberK = 0;
        int numberN = 0;
        string readStr;
        bool parseSuccess = false;

        do
        {
            Console.Write("Enter positive number N: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out numberN);
        }
        while (parseSuccess == false || numberN < 1);

        do
        {
            Console.Write("Enter positive number K > N: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out numberK);
        }
        while (parseSuccess == false || numberK < numberN);

        BigInteger result = 1;

        for (int i = (numberK - numberN +1); i <= numberK; i++)
        {
            result *= i;
        }

        for (int i = 1; i <= numberN; i++)
        {
            result *= i;
        }

        Console.WriteLine("\n\rResult N! * K! / (K-N)! = {0}.\n\r", result);
    }
}
