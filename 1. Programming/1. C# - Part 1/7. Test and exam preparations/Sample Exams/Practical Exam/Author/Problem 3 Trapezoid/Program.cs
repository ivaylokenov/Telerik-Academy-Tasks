using System;

namespace Problem_3_Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input
            string nAsString = Console.ReadLine();
            int N = int.Parse(nAsString);

            // Output first row
            for (int i = 1; i <= N; i++)
            {
                Console.Write('.');
            }
            for (int i = 1; i <= N; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();

            // Output middle rows
            for (int i = 2; i <= N; i++)
            {
                for (int j = 1; j <= N - i + 1; j++)
                {
                    Console.Write('.');
                }
                Console.Write('*');
                for (int j = 1; j <= i + N - 3; j++)
                {
                    Console.Write('.');
                }
                Console.Write('*');
                Console.WriteLine();
            }

            // Output last row
            for (int i = 1; i <= 2 * N; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }
}
