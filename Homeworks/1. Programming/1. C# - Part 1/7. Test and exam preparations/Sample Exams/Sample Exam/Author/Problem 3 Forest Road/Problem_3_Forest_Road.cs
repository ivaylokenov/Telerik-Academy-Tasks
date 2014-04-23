using System;

namespace Problem_3_Forest_Road
{
    class Problem_3_Forest_Road
    {
        static void Main()
        {
            // Read input
            int N = int.Parse(Console.ReadLine());

            // Write first part
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

            // Write second part
            for (int i = N - 1; i >= 0; i--)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
