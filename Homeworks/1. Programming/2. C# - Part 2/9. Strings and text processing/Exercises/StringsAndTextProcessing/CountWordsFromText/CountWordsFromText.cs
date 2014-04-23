using System;
using System.Collections.Generic;
using System.Text;

class CountWordsFromText
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] separatedInput = input.Split(' ');

        Dictionary<string, int> separatedWords = new Dictionary<string, int>();

        for (int i = 0; i < separatedInput.Length; i++)
        {
            if (separatedWords.ContainsKey(separatedInput[i]))
            {
                separatedWords[separatedInput[i]]++;
            }
            else
            {
                separatedWords.Add(separatedInput[i], 1);
            }
        }

        foreach (KeyValuePair<string, int> kvp in separatedWords)
        {
            Console.WriteLine("{0}: {1} times", kvp.Key, kvp.Value);
        }
    }
}