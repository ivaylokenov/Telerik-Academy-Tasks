using System;

class BiggerThanNeighbours
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

    static void Main()
    {
        //read input
        int[] arrayOfNumbers = { 1, 2, 3, 4, 3, 2, 1 };
        int position = 3;

        if (position != 0 && position != (arrayOfNumbers.Length - 1))
        {
            Console.WriteLine("Is bigger: " + IsBiggerThanNeighbours(arrayOfNumbers, position) + ".");
        }
        else
        {
            Console.WriteLine("This position does not have two neighbours.");
        }
    }
}
