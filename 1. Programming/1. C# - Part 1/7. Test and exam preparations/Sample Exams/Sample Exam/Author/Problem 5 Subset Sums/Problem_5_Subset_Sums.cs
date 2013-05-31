using System;

namespace Problem_5_Subset_Sums
{
    class Problem_5_Subset_Sums
    {
        static void Main()
        {
            // Read input data
            long S = long.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            long n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16;
            n1 = n2 = n3 = n4 = n5 = n6 = n7 = n8 = n9 = n10 = n11 = n12 = n13 = n14 = n15 = n16 = 0L;
            for (int i = 1; i <= N; i++)
            {
                if (i == 1) n1 = long.Parse(Console.ReadLine());
                if (i == 2) n2 = long.Parse(Console.ReadLine());
                if (i == 3) n3 = long.Parse(Console.ReadLine());
                if (i == 4) n4 = long.Parse(Console.ReadLine());
                if (i == 5) n5 = long.Parse(Console.ReadLine());
                if (i == 6) n6 = long.Parse(Console.ReadLine());
                if (i == 7) n7 = long.Parse(Console.ReadLine());
                if (i == 8) n8 = long.Parse(Console.ReadLine());
                if (i == 9) n9 = long.Parse(Console.ReadLine());
                if (i == 10) n10 = long.Parse(Console.ReadLine());
                if (i == 11) n11 = long.Parse(Console.ReadLine());
                if (i == 12) n12 = long.Parse(Console.ReadLine());
                if (i == 13) n13 = long.Parse(Console.ReadLine());
                if (i == 14) n14 = long.Parse(Console.ReadLine());
                if (i == 15) n15 = long.Parse(Console.ReadLine());
                if (i == 16) n16 = long.Parse(Console.ReadLine());
            }

            // Find answer
            int answer = 0;
            int maxi = (int)Math.Pow(2, N) - 1;
            for (int i = 1; i <= maxi; i++)
            {
                long currentSum = 0;
                for (int j = 1; j <= N; j++)
                {
                    if (((i >> (j - 1)) & 1) == 1)
                    {
                        if (j == 1) currentSum += n1;
                        if (j == 2) currentSum += n2;
                        if (j == 3) currentSum += n3;
                        if (j == 4) currentSum += n4;
                        if (j == 5) currentSum += n5;
                        if (j == 6) currentSum += n6;
                        if (j == 7) currentSum += n7;
                        if (j == 8) currentSum += n8;
                        if (j == 9) currentSum += n9;
                        if (j == 10) currentSum += n10;
                        if (j == 11) currentSum += n11;
                        if (j == 12) currentSum += n12;
                        if (j == 13) currentSum += n13;
                        if (j == 14) currentSum += n14;
                        if (j == 15) currentSum += n15;
                        if (j == 16) currentSum += n16;
                    }
                }
                if (currentSum == S) answer++;
            }

            // Write output data
            Console.WriteLine(answer);
        }
    }
}
