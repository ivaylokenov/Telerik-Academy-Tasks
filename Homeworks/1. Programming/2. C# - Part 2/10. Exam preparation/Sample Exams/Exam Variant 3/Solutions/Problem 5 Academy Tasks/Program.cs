using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_5_Academy_Tasks
{
    class Program
    {
        static void Main()
        {
            string pleasantnessAsString = Console.ReadLine();
            int variety = int.Parse(Console.ReadLine());
            string[] pleasantnessParts = pleasantnessAsString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] pleasantness = pleasantnessParts.Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(minNumber(pleasantness, variety));
        }

        static int minNumber(int[] pleasantness, int variety)
        {
            int res = pleasantness.Length;
            for (int i = 0; i < pleasantness.Length; i++)
            {
                for (int j = i + 1; j < pleasantness.Length; j++)
                {
                    int diff = Math.Abs(pleasantness[i] - pleasantness[j]);
                    if (diff < variety)
                    {
                        continue;
                    }
                    int act = (i + 3) / 2;
                    int k = (j - i);
                    act += (k + 1) / 2;
                    res = Math.Min(res, act);
                }
            }
            return res;
        } 
    }
}
