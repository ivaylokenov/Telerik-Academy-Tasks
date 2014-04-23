using System;

namespace Problem_2_Least_Majority_Multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            // Output
            for (int i = 1; true; i++)
            {
                int count = 0;
                if (i % a == 0) count++;
                if (i % b == 0) count++;
                if (i % c == 0) count++;
                if (i % d == 0) count++;
                if (i % e == 0) count++;
                if (count >= 3)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
