using System;

class BinaryDigitsCount
{
    static void Main()
    {
        string readStr = Console.ReadLine();
        byte B = byte.Parse(readStr);
        readStr = Console.ReadLine();
        ushort N = ushort.Parse(readStr);
        uint currentNumber;
        Int64 binaryHolder;
        int[] sumOfBinary = new int[N];

        for (int i = 0; i < N; i++)
        {
            sumOfBinary[i] = 0;
        }

        for (int i = 0; i < N; i++)
        {
            readStr = Console.ReadLine();
            currentNumber = uint.Parse(readStr);
            while (currentNumber > 0)
            {
                binaryHolder = currentNumber % 2;
                if (binaryHolder == B)
                {
                    sumOfBinary[i]++;
                }
                currentNumber /= 2;
            }
        }

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(sumOfBinary[i]);
        }
    }
}
