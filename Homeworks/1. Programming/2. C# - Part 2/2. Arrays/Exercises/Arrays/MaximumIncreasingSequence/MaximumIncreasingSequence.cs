using System;

class MaximumIncreasingSequence
{
    static void Main()
    {
        //int[] array = { 3, 2, 3, 4, 5, 6, 7, 8, 2, 2, 4, 5, 6, 7 };
        int[] array = { 42, 41, 20, 12, 1, 2, 3, 4};
        int maxSequence = 0;
        int sequence = 1;
        string sequenceNumbers = "";
        string maxSequenceNumbers = "";
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] < array[i + 1])
            {
                sequence++;
                sequenceNumbers += array[i] + " ";
            }
            else
            {
                if (maxSequence < sequence)
                {
                    maxSequence = sequence;
                    sequenceNumbers += array[i] + " ";
                    maxSequenceNumbers = sequenceNumbers;
                }
                sequence = 1;
                sequenceNumbers = "";
            }
        }

        if (maxSequence < sequence)
        {
            sequenceNumbers += array[array.Length - 1];
            maxSequenceNumbers = sequenceNumbers;
        }

        Console.WriteLine(maxSequenceNumbers);
    }
}
