using System;

class SortingMethod
{
    //sort array by element's length
    static void SortArrayByLenghtOfElements(string[] array)
    {
        int minimumValue;
        for (int i = 0; i < array.Length - 1; i++)
        {
            minimumValue = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j].Length < array[minimumValue].Length)
                {
                    minimumValue = j;
                }
            }

            if (minimumValue != i)
            {
                string temporaryVariable = array[minimumValue];
                array[minimumValue] = array[i];
                array[i] = temporaryVariable;
            }
        }
    }

    static void Main()
    {
        string[] arrayOfStrings = new string[6] { "abcdeddsadsafdfddfsada", "abcde", "abcdgfdgfd", "abc", "ab", "adsadsadsadas" };

        //sort elements
        SortArrayByLenghtOfElements(arrayOfStrings);

        //print elements in sorted way
        for (int i = 0; i < arrayOfStrings.Length; i++)
        {
            Console.WriteLine(arrayOfStrings[i] + " ");
        }
    }
}
