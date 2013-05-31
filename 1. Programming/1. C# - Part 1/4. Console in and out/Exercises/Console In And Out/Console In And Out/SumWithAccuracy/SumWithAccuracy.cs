using System;
using System.Globalization;
using System.Threading;

class SumWithAccuracy
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Fibonacci";
        string title = new string('-', 57);
        Console.WriteLine(title);
        Console.WriteLine("This program calculates a sequence with accuracy of 0.001");
        Console.WriteLine(title + "\n\r");
        Console.WriteLine("Sequence is: 1 + 1/2 - 1/3 + 1/4 - 1/5 + 1/6 - 1/7...\n\r");
        decimal sumOfSequence = 1M, tempSum = 0M, i = 2M;
        while (Math.Abs((double)tempSum - (double)sumOfSequence) > 0.001)
        {
            tempSum = sumOfSequence;
            if (i % 2 == 0)
            {
                sumOfSequence += (1 / i);
            }
            else
            {
                sumOfSequence -= (1 / i);
            }
            i++;
        }
        
        Console.WriteLine("The sum is: {0:F10}.\n\r", sumOfSequence);
    }
}
