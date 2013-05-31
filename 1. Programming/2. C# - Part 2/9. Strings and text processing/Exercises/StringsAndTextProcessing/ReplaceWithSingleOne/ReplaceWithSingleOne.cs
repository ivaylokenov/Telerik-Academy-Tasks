using System;
using System.Text;

class ReplaceWithSingleOne
{
    static void Main()
    {
        string input = Console.ReadLine();

        Console.Write(input[0]);

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                Console.Write(input[i]);
            }
        }

        Console.WriteLine();
    }
}
