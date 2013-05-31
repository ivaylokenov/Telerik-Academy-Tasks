using System;

namespace Problem_3_Fir_Tree
{
    class Program
    {
        static void Main()
        {
            // Read the input
            int N = int.Parse(Console.ReadLine());

            // Write the tree
            for (int i = 0; i < N - 1; i++)
            {
                string dots = new String('.', (N - i) - 2);
                string stars = new String('*', (i * 2) + 1);
                Console.Write(dots);
                Console.Write(stars);
                Console.Write(dots);
                Console.WriteLine();
            }

            // Write the stem
            string finalDots = new string('.', N - 2);
            Console.Write(finalDots);
            Console.Write("*");
            Console.Write(finalDots);
            Console.WriteLine();
        }
    }
}
