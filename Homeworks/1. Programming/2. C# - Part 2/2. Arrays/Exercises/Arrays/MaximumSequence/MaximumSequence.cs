using System;

class MaximumSequence
{
    static void Main()
    {
        int[] array = { 2, 1, 1, 2, 3, 3, 3, 5, 5, 5, 5, 2, 2, 1 };
        int maxSequence = 0;
        int sequence = 1;
        string sequenceNumbers = "";
        string maxSequenceNumbers = "";
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
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
        Console.WriteLine(maxSequenceNumbers);
    }
}
