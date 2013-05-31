using System;

class OddNumber
{
    static void Main()
    {
        string readStr = Console.ReadLine();
        int N = int.Parse(readStr);
        long currentNumber, result = 0;
        for (int i = 0; i < N; i++)
        {
            readStr = Console.ReadLine();
            currentNumber = long.Parse(readStr);
            result ^= currentNumber;
        }
        Console.WriteLine(result);
    }
}
