using System;
using System.Collections.Generic;
using System.Text;

class Tubes
{
    static void Main()
    {
        //BGCoder: 35/100

        int N = int.Parse(Console.ReadLine()); //tubes
        int M = int.Parse(Console.ReadLine()); //needed tubes

        int[] tubesSize = new int[N];
        int totalSum = 0;

        int minSizeTube = 0;

        for (int i = 0; i < N; i++)
        {
            tubesSize[i] = int.Parse(Console.ReadLine());
            totalSum += tubesSize[i];
            if (tubesSize[i] > minSizeTube)
            {
                minSizeTube = tubesSize[i];
            }
        }

        if (M > totalSum)
        {
            Console.WriteLine(-1);
            return;
        }

        int maxSize = (int)((decimal)totalSum / (decimal)M);

        //int maxSize = minSizeTube;
        //maxSize = Math.Min(minSizeTube, maxSize);

        int result = -1;

        Array.Sort(tubesSize);

        for (int i = maxSize; i > 0; i--)
        {
            int numberOfCuts = 0;

            for (int j = tubesSize.Length - 1; j >= 0; j--)
            {
                int currentMaxSize = tubesSize[j] / i;
                numberOfCuts += currentMaxSize;
            }

            if (numberOfCuts >= M)
            {
                result = i;
                break;
            }
        }

        Console.WriteLine(result);
    }
}
