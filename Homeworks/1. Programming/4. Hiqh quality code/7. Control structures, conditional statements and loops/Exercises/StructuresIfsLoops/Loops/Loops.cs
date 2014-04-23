using System;

public class Loops
{
    public static void Main()
    {
        int[] arrayOfIntegers = new int[100];
        int expectedValue = 0;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(arrayOfIntegers[i]);

            if (i % 10 == 0 && arrayOfIntegers[i] == expectedValue)
            {
                Console.WriteLine("Value Found");
                break;
            }
        }
    }
}
