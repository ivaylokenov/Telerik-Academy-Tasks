using System;

class DancingBits
{
    static void Main()
    {
        int K = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        string concatenatedBits = "";
        for (int i = 1; i <= N; i++)
        {
            long value = long.Parse(Console.ReadLine());
            concatenatedBits += Convert.ToString(value, 2);
        }
        int lenghtOfSequence = 0;
        char previousBit = '2';
        int result = 0;
        for (int i = 0; i < concatenatedBits.Length; i++)
        {
            if (concatenatedBits[i] == previousBit)
            {
                lenghtOfSequence += 1;
            }
            else
            {
                if (lenghtOfSequence == K)
                {
                    result += 1;
                }
                lenghtOfSequence = 1;
            }
            previousBit = concatenatedBits[i];
        }
        if (lenghtOfSequence == K)
        {
            result += 1;
        }
        Console.WriteLine(result);
    }
}
