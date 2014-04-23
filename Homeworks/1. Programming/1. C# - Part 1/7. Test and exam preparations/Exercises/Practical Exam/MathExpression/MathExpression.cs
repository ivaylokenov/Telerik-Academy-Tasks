using System;

class MathExpression
{
    static void Main(string[] args)
    {
        string readStr = Console.ReadLine();
        decimal N = decimal.Parse(readStr);
        readStr = Console.ReadLine();
        decimal M = decimal.Parse(readStr);
        readStr = Console.ReadLine();
        decimal P = decimal.Parse(readStr);
        decimal angle = (int)(M % 180);
        angle = (decimal)Math.Sin((double)angle);
        decimal result = ((N * N + 1 / (M * P) + 1337M) / (N - 128.523123123M * P)) + angle;
        Console.WriteLine("{0:0.000000}", result);
    }
}