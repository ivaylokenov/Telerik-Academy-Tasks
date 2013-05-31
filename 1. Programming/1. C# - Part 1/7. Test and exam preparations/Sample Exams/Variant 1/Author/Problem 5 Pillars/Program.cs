using System;

namespace Problem_5_Pillars
{
    class Program
    {
        static void Main()
        {
            // Read the input numbers
            int num0 = Int32.Parse(Console.ReadLine());
            int num1 = Int32.Parse(Console.ReadLine());
            int num2 = Int32.Parse(Console.ReadLine());
            int num3 = Int32.Parse(Console.ReadLine());
            int num4 = Int32.Parse(Console.ReadLine());
            int num5 = Int32.Parse(Console.ReadLine());
            int num6 = Int32.Parse(Console.ReadLine());
            int num7 = Int32.Parse(Console.ReadLine());

            // Solve the task
            int bestCount = Int32.MinValue;
            int bestIndex = Int32.MinValue;
            for (int index = 0; index <= 7; index++)
            {
                int leftCount = 0;
                for (int leftIndex = index + 1; leftIndex <= 7; leftIndex++)
                {
                    leftCount += (num0 >> leftIndex) & 1;
                    leftCount += (num1 >> leftIndex) & 1;
                    leftCount += (num2 >> leftIndex) & 1;
                    leftCount += (num3 >> leftIndex) & 1;
                    leftCount += (num4 >> leftIndex) & 1;
                    leftCount += (num5 >> leftIndex) & 1;
                    leftCount += (num6 >> leftIndex) & 1;
                    leftCount += (num7 >> leftIndex) & 1;
                }

                int rightCount = 0;
                for (int rightIndex = 0; rightIndex <= index - 1; rightIndex++)
                {
                    rightCount += (num0 >> rightIndex) & 1;
                    rightCount += (num1 >> rightIndex) & 1;
                    rightCount += (num2 >> rightIndex) & 1;
                    rightCount += (num3 >> rightIndex) & 1;
                    rightCount += (num4 >> rightIndex) & 1;
                    rightCount += (num5 >> rightIndex) & 1;
                    rightCount += (num6 >> rightIndex) & 1;
                    rightCount += (num7 >> rightIndex) & 1;
                }

                if (leftCount == rightCount)
                {
                    bestCount = leftCount;
                    bestIndex = index;
                }
            }

            if (bestCount != Int32.MinValue)
            {
                Console.WriteLine(bestIndex);
                Console.WriteLine(bestCount);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
