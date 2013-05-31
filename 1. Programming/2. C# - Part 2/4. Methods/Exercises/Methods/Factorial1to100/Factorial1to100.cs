using System;
using System.Numerics;

class Factorial1to100
{
    //returns factorial from a number
    static BigInteger Factorial(int number)
    {
        BigInteger factorial = 1;

        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }

    static void Main()
    {
        //set console dimensions
        Console.BufferWidth = 165;
        Console.WindowWidth = 165;
        Console.WindowHeight = 50;
        Console.BufferHeight = 120;

        //print factorials
        for (int i = 1; i <= 100; i++)
        {
            Console.Write(i + ": ");
            Console.WriteLine(Factorial(i));
        }
    }
}
