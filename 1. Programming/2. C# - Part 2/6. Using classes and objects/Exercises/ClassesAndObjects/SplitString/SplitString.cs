using System;

class SplitString
{
    static int StringSplit(string input)
    {
        int result = 0;
        string[] separatedString = input.Split();
        foreach (var number in separatedString)
        {
            result += int.Parse(number);
        }
        return result;
    }

    static void Main()
    {
        string input = "43 68 9 23 318";
        Console.WriteLine(StringSplit(input));
    }
}
