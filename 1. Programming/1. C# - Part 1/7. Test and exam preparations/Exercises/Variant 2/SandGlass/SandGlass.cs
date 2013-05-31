using System;

class SandGlass
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 1; i <= N / 2 + 1; i++)
        {
            for (int j = 1; j <= N / 2 + 1; j++)
            {
                if (i <= j)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            for (int k = N / 2; k >= 1; k--)
            {
                if (k >= i)
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
        for (int i = N / 2; i >= 1; i--)
        {
            for (int j = 1; j <= N / 2 + 1; j++)
            {
                if (j >= i)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            for (int k = N/2; k >= 1; k--)
            {
                if (k >= i)
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
