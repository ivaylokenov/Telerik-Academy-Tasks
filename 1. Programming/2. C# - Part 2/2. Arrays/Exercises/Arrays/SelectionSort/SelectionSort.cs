using System;

class SelectionSort
{
    static void Main(string[] args)
    {
        int[] array = { 4, 5, 6, 2, 3, 4, 5, - 6, 0, -9, -10, 11, 14, -5465 };

        int minimumValue;

        for (int i = 0; i < array.Length - 1; i++)
        {
            minimumValue = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minimumValue])
                {
                    minimumValue = j;
                }
            }

            if (minimumValue != i)
            {
                int temporaryVariable = array[minimumValue];
                array[minimumValue] = array[i];
                array[i] = temporaryVariable;
            }
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
