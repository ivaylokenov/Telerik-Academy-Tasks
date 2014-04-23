using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter lenght of first array: ");
        int lenghtOfFirstArray = int.Parse(Console.ReadLine());
        Console.Write("Enter lenght of second array: ");
        int lenghtOfSecondArray = int.Parse(Console.ReadLine());
        int[] firstArray = new int[lenghtOfFirstArray];
        int[] secondArray = new int[lenghtOfSecondArray];

        for (int i = 0; i < lenghtOfFirstArray; i++)
        {
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < lenghtOfSecondArray; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        bool isSame = true;

        if (lenghtOfFirstArray != lenghtOfSecondArray)
        {
            isSame = false;
        }
        else
        {
            for (int i = 0; i < lenghtOfFirstArray; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    isSame = false;
                }
            }
        }
        Console.WriteLine("Your arrays are the same - {0}.", isSame);
    }
}
