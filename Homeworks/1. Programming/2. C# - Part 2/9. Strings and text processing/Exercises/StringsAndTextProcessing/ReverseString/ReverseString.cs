using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string input = "sample";

        StringBuilder output = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            output.Append(input[i]);
        }

        Console.WriteLine(output.ToString());
    }
}
