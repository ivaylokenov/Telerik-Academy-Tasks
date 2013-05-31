using System;

class CompareCharArrays
{
    static void Main()
    {
        char[] firstArray = { 'P', 'e', 's', 'h' };
        char[] secondArray = { 'P', 'e', 's', 'h', 'o' };
        int maxLenght;
        int smallerArray = 0;
        if (firstArray.Length <= secondArray.Length)
        {
            maxLenght = firstArray.Length;
        }
        else
        {
            maxLenght = secondArray.Length;
        }

        for (int i = 0; i < maxLenght; i++)
        {
            if (firstArray[i] < secondArray[i])
            {
                smallerArray = 1;
                break;
            }
            else if (firstArray[i] > secondArray[i])
            {
                smallerArray = 2;
                break;
            }
        }

        if (smallerArray == 1)
        {
            Console.WriteLine("The first array is earlier.");
        }
        else if (smallerArray == 2)
        {
            Console.WriteLine("The second array is earlier.");
        }
        else
        {
            if (firstArray.Length > secondArray.Length)
            {
                Console.WriteLine("The second array is earlier.");
            }
            else if (firstArray.Length < secondArray.Length)
            {
                Console.WriteLine("The first array is earlier.");
            }
            else
            {
                Console.WriteLine("The two arrays are the same.");
            }
        }
    }
}
