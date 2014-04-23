using System;

class FirTree
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N; i++)
        {
            if (i < N)
            {
                for (int j = N - 1; j > 0; j--)
                {
                    if (i >= j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                for (int k = 1; k < N - 1; k++)
                {
                    if (i > k)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            else
            {
                for (int j = 1; j <= N*2 - 3; j++)
                {
                    if (j == N - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
