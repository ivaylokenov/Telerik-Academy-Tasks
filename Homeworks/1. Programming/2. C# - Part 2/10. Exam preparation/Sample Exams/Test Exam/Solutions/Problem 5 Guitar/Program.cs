using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5_Guitar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] intervals = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int beginLevel = int.Parse(Console.ReadLine());
            int maxLevel = int.Parse(Console.ReadLine());
            int[] changeIntervals = new int[intervals.Length];
            for (int i = 0; i < intervals.Length; i++)
            {
                changeIntervals[i] = int.Parse(intervals[i]);
            }
            int answer = maxFinal(changeIntervals, beginLevel, maxLevel);
            Console.WriteLine(answer);
        }

        static int maxFinal(int[] changeIntervals, int beginLevel, int maxLevel)
        {
            int n = changeIntervals.Length;
            int[,] a = new int[n + 1, maxLevel + 1];
            a[0, beginLevel] = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= maxLevel; j++)
                {
                    if (a[i - 1, j] == 1)
                    {
                        int x = changeIntervals[i - 1];
                        if (j - x >= 0)
                        {
                            a[i, j - x] = 1;
                        }
                        if (j + x <= maxLevel)
                        {
                            a[i, j + x] = 1;
                        }
                    }
                }
            }

            for (int i = maxLevel; i >= 0; i--)
            {
                if (a[n, i] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
