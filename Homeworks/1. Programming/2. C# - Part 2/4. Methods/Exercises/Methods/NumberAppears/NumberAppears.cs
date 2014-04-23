using System;

class NumberAppears
{
    //checks how many times number appears in an array
    static int NumberAppearsInArr(int[] array, int number)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (number == array[i])
            {
                counter++;
            }
        }
        return counter;
    }

    static void Main()
    {
        int[] arrayOfNumber = { 1, 2, 3, 4, 5, 1, 1, 2 };
        int number = 1;
        Console.WriteLine(NumberAppearsInArr(arrayOfNumber, number));
    }
}
