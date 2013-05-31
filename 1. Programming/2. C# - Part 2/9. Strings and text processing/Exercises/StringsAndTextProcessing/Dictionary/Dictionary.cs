using System;
using System.Text;

class Dictionary
{
    static void Main()
    {
        string dictionary = ".NET – platform for applications from Microsoft\n\rCLR – managed execution environment for .NET\n\rnamespace – hierarchical organization of classes";

        string[] separatedDictionary = dictionary.Split('\n', '\r');

        string input = Console.ReadLine();

        foreach (var item in separatedDictionary)
        {
            if (item.Length >= input.Length)
            {
                int index = string.Compare(item.Substring(0, input.Length), input, true);

                if (index == 0)
                {
                    string output = item.Substring(input.Length + 3);
                    Console.WriteLine(output);
                    return;
                }
            }
        }

        Console.WriteLine("Word was not found in dictionary.");
    }
}
