using System;
using System.Text;

class SortWords
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] words = input.Split(' ');

        Array.Sort(words);

        for (int i = 0; i < words.Length; i++)
        {
            Console.Write(words[i] + " ");
        }

        Console.WriteLine();
    }
}
