using System;

class Trapezoid
{
    static void Main()
    {
        string readStr = Console.ReadLine();
        int N = int.Parse(readStr);
        for (int i = 1; i <= N; i++)
        {
            Console.Write(".");
        }
        for (int i = N +1; i <= N*2; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
        for (int i = 1; i <= N - 1; i++)
        {
            for (int j = N; j > 0; j--)
            {
                if (i == j)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }

            for (int k = 1; k <= N; k++)
            {
                if (k == N)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }

            Console.WriteLine();
        }
        for (int i = 1; i <= N*2; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}
