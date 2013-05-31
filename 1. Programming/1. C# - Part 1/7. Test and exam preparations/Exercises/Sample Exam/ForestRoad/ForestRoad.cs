using System;

class ForestRoad
{
    static void Main()
    {
        string readStr = Console.ReadLine();
        int N = int.Parse(readStr);
        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= N; j++)
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
            Console.WriteLine();
        }

        for (int i = N-1; i > 0; i--)
        {
            for (int j = 1; j <= N; j++)
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
            Console.WriteLine();
        }
    }
}
