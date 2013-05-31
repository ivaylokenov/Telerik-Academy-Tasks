using System;
using System.Collections.Generic;

class MaximumElementAndSort
{
    //maximum element starting at given index
    static int MaxElementFromIndex(int[] array, int position)
    {
        int maxElement = int.MinValue;
        int maxPosition = 0;

        for (int i = position; i < array.Length; i++)
        {
            if (maxElement < array[i])
            {
                maxElement = array[i];
                maxPosition = i;
            }
        }

        return maxPosition;
    }

    //sorts in ascending order
    static void SortArrayAscending(params int[] array)
    {
        int currentMaxPosition = 0;
        int temporaryValue = 0;

        for (int i = 0; i < array.Length; i++)
        {
            currentMaxPosition = MaxElementFromIndex(array, i);
            temporaryValue = array[i];
            array[i] = array[currentMaxPosition];
            array[currentMaxPosition] = temporaryValue;
        }

        Array.Reverse(array);
    }

    //sorts in descending order
    static void SortArrayDescending(params int[] array)
    {
        int currentMaxPosition = 0;
        int temporaryValue = 0;

        for (int i = 0; i < array.Length; i++)
        {
            currentMaxPosition = MaxElementFromIndex(array, i);
            temporaryValue = array[i];
            array[i] = array[currentMaxPosition];
            array[currentMaxPosition] = temporaryValue;
        }
    }

    //prints an array
    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }

    static void Main()
    {
        //input data
        int[] arrayOfIntegers = { 5, 8, 2, 7, 5, 8, 4 };

        //sort elements in descending order
        SortArrayDescending(arrayOfIntegers);

        //print the array
        PrintArray(arrayOfIntegers);

        Console.WriteLine();

        //another array
        int[] anotherArrayOfIntegers = { 5, 9, 2, 3, 1, 5, 8, 6 };

        //sort elements in ascending order
        SortArrayAscending(anotherArrayOfIntegers);

        //print the array
        PrintArray(anotherArrayOfIntegers);

        Console.WriteLine();
    }
}
