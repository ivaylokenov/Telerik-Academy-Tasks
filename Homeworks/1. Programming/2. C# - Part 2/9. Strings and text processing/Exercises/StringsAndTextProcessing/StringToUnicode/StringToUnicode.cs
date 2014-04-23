using System;
using System.Text;

class StringToUnicode
{
    static void Main()
    {
        string input = "Hi!";

        foreach (var character in input)
        {
            Console.Write("\\u{0:X4}", (int)character);
        }

        Console.WriteLine();
    }
}
