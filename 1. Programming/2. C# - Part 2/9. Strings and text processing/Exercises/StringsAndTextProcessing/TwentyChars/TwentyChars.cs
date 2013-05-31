using System;
using System.Text;

class TwentyChars
{
    static void Main()
    {
        Console.Write("Enter string of < 20 characters: ");
        string input = Console.ReadLine();

        if (input.Length > 20)
        {
            Console.WriteLine("Your input is longer than 20 characters.");
            return;
        }

        StringBuilder result = new StringBuilder();
        result.Append(input);

        for (int i = input.Length + 1; i <= 20; i++)
        {
            result.Append("*");
        }

        Console.WriteLine(result);
    }
}
