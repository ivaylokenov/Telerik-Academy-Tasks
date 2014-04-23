using System;

class SumCalculation
{
    static void Main()
    {
        string title = new string('-', 62);
        Console.Title = "Sum";
        Console.WriteLine(title);
        Console.WriteLine("This program calculates S = 1 + 1!/X^1 + 2!/X^2 + ... + N!/X^N");
        Console.WriteLine(title + "\n\r");
        decimal numberX = 0m;
        decimal numberN = 0m;
        string readStr;
        bool parseSuccess = false;

        do
        {
            Console.Write("Enter positive number N > 0: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out numberN);
        }
        while (parseSuccess == false || numberN < 1);

        do
        {
            Console.Write("Enter number X != 0: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out numberX);
        }
        while (parseSuccess == false || numberX == 0);

        decimal factorial = 1, power = 1, sum = 1;

        for (int i = 1; i <= numberN; i++)
        {
            factorial *= i;
            power *= numberX;
            sum += (factorial / power);
        }
        Console.WriteLine("\n\rResult of sum S = 1 + 1!/X^1 + 2!/X^2 + ... + N!/X^N:\n\r{0:0.0000}.\n\r",sum);
    }
}
