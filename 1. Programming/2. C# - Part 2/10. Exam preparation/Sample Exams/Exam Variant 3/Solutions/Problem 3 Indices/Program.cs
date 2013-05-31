using System;
using System.Text;
using System.Diagnostics;

namespace Problem_3_Indices
{
    class Program
    {
        static void Main()
        {
            //TestsGenerator.PathPlusCyclePlusExit(200000);
            //return;

            int N = int.Parse(Console.ReadLine());
            int[] numbers = new int[N];
            string numbersAsStringLine = Console.ReadLine();
            string[] numbersAsStrings = numbersAsStringLine.Split(' ');
            for (int i = 0; i < N; i++)
			{
			    numbers[i] = int.Parse(numbersAsStrings[i]);
			}
            bool[] used = new bool[N];
            int firstElementInCycle = 0;
            int lastElementInCycle = 0;
            bool hasCycle = false;
            while (firstElementInCycle >= 0 && firstElementInCycle < N)
            {
                if (used[firstElementInCycle])
                {
                    hasCycle = true;
                    break;
                }
                used[firstElementInCycle] = true;
                lastElementInCycle = firstElementInCycle;
                firstElementInCycle = numbers[lastElementInCycle];
            }

            int c = 0;
            StringBuilder sb = new StringBuilder();
            while (c >= 0 && c < N)
            {
                if (c == firstElementInCycle && c == lastElementInCycle && hasCycle)
                {
                    if (sb.Length > 0 && sb[sb.Length - 1] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.AppendFormat("({0}) ", c.ToString());
                    break;
                }
                else if (c == lastElementInCycle && hasCycle)
                {
                    sb.AppendFormat("{0})", c.ToString());
                    break;
                }
                else if (c == firstElementInCycle && hasCycle)
                {
                    if (sb.Length > 0 && sb[sb.Length - 1] == ' ')
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.AppendFormat("({0} ", c.ToString());
                }
                else
                {
                    sb.AppendFormat("{0} ", c.ToString());
                }
                c = numbers[c];
            }
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
