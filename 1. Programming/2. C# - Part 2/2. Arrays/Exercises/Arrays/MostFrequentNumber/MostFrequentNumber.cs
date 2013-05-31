using System;

class MostFrequentNumber
{
    static void Main()
    {
        int[] array = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 1, 1, 1, 1, 2, 4, 9, 3 };
        int frequentNumber = 0;
        int numberOfRepetitions = 1;
        int maximumRepetitions = int.MinValue;
        int mostFrequentNumber = int.MinValue;
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    frequentNumber = array[i];
                    numberOfRepetitions++;
                }
            }

            if (maximumRepetitions < numberOfRepetitions)
            {
                maximumRepetitions = numberOfRepetitions;
                mostFrequentNumber = frequentNumber;
            }
            numberOfRepetitions = 1;

        }
        Console.WriteLine("Most frequent number: {0}. Repeated {1} times.", mostFrequentNumber, maximumRepetitions);
    }
}
