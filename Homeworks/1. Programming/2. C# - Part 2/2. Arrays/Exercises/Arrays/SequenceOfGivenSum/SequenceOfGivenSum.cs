using System;

class SequenceOfGivenSum
{
    static void Main()
    {
        int[] array = { 4, 3, 1, 4, 2, 5, 8 };
        int S = int.Parse(Console.ReadLine());
        int start = 0;
        int sum = 0;
        for (int i = 0; i < array.Length - 1; i++)
        {
            sum += array[i];
            start = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                sum += array[j];
                if (sum == S)
                {
                    for (int k = start; k <= j; k++)
                    {
                        Console.Write(array[k] + " ");
                    }
                    return;
                }
            }
            sum = 0;
        }
        Console.WriteLine("The sum is not present in the array.");
    }
}
