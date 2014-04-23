using System;

namespace Problem_4_Binary_Digits_Count
{
    class Problem_4_Binary_Digits_Count
    {
        static void Main()
        {
            // Read input
            byte B = byte.Parse(Console.ReadLine());
            short N = short.Parse(Console.ReadLine());

            // Solve
            for (int i = 1; i <= N; i++)
            {
                int count = 0;
                uint number = uint.Parse(Console.ReadLine());
                while (number != 0)
                {
                    if ((number & 1) == B)
                    {
                        count++;
                    }
                    number = number >> 1;
                }

                // Write answers
                Console.WriteLine(count);
            }
        }
    }
}
