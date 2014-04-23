using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        BigInteger[] tribonacci = new BigInteger[N];
        tribonacci[0] = firstNumber;
        tribonacci[1] = secondNumber;
        tribonacci[2] = thirdNumber;
        for (int i = 3; i < N; i++)
        {
            tribonacci[i] = tribonacci[i - 1] + tribonacci[i - 2] + tribonacci[i - 3];
        }
        Console.WriteLine(tribonacci[N-1]);
    }
}
