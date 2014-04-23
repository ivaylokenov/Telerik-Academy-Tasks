using System;
using System.Collections.Generic;

class MaximumSumOfK
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array element {0}: ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter K: ");
        int K = int.Parse(Console.ReadLine());

        int checkedNumbers = 0;
        List<int> subsetNumbers = new List<int>();
        int maxi = (int)Math.Pow(2, array.Length) - 1;
        int maxSum = int.MinValue;
        int[] maxSumArray = new int[K];

        for (int i = 1; i <= maxi; i++)
        {
            int currentSum = 0;
            for (int j = 1; j <= array.Length; j++)
            {
                if (((i >> (j - 1)) & 1) == 1)
                {
                    currentSum += array[j - 1];
                    checkedNumbers++;
                    subsetNumbers.Add(array[j - 1]);
                }
            }

            if (checkedNumbers == K && currentSum > maxSum)
            {
                maxSum = currentSum;
                for (int k = 0; k < maxSumArray.Length; k++)
                {
                    maxSumArray[k] = subsetNumbers[k];
                }
            }
            subsetNumbers.Clear();
            checkedNumbers = 0;
        }

        if (maxSum > int.MinValue)
        {
            for (int i = 0; i < K; i++)
            {
                Console.Write(maxSumArray[i] + " ");
            }
        }
        else
        {
            Console.Write("No such subset.");
        }
        Console.WriteLine();
    }
}
