using System;

class FirstElementBigger
{
    //checks whether two neighbours in array are bigger than a given position
    static bool IsBiggerThanNeighbours(int[] array, int position)
    {
        if (array[position] > array[position - 1] && array[position] > array[position + 1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //returns the first index where the number is bigger than its neighbours
    static int FirstIndexBigger(int[] array)
    {
        for (int i = 1; i < array.Length - 1; i++)
        {
            if (IsBiggerThanNeighbours(array, i))
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        //input
        int[] arrayOfNumbers = { 1, 2, 3, 4, 10, 7, 8 };

        //print result
        Console.WriteLine("The first element which is bigger than its neighbours is at position {0}.", FirstIndexBigger(arrayOfNumbers));
    }
}