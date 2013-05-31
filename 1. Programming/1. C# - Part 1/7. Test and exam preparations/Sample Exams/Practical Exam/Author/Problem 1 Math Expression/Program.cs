using System;
using System.Threading;
using System.Globalization;

namespace Problem_1_Math_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting invariant culture to avoid problems with floating point
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Read N
            string nAsString = Console.ReadLine();
            decimal N = decimal.Parse(nAsString);

            // Read M
            string mAsString = Console.ReadLine();
            decimal M = decimal.Parse(mAsString);

            // Read P
            string pAsString = Console.ReadLine();
            decimal P = decimal.Parse(pAsString);

            // Calculating expression
            decimal result =
                (N * N + (1 / (M * P)) + 1337) /
                (N - 128.523123123M * P)
                + (decimal)Math.Sin((int)M % 180);

            // Write the result to the console
            Console.WriteLine("{0:0.000000}", result);
        }
    }
}
