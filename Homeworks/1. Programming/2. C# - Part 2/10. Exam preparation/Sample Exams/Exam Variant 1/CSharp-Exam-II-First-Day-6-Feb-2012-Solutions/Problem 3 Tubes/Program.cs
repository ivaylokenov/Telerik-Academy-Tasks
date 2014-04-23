using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_3_Tubes
{
    class Program
    {
        static void Main()
        {
            //TestsGenerator.GenerateTests(); return;

            // Input
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            long sum = 0;
            List<int> tubes = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int temp = int.Parse(Console.ReadLine());
                sum += temp;
                tubes.Add(temp);
            }

            if (M > sum)
            {
                Console.WriteLine(-1);
                return;
            }

            // Binary search - aproximating the answer
            int down = 0;
            int up = (int)Math.Ceiling((double)sum / (double)M);
            while (down < up)
            {
                int count = 0;
                int mid = (down + up) / 2;
                if (mid == 0)
                {
                    down = 1;
                    break;
                }
                foreach (var tube in tubes)
                {
                    count += tube / mid;
                }
                if (count < M)
                {
                    up = mid;
                }
                else
                {
                    down = mid + 1;
                }
            }

            // Correct the answer
            for (; down >= 1; down--)
            {
                int count = 0;
                foreach (var tube in tubes)
                {
                    count += tube / down;
                }
                if (count >= M)
                {
                    break;
                }
            }

            // Output
            Console.WriteLine(down);
        }
    }
}
