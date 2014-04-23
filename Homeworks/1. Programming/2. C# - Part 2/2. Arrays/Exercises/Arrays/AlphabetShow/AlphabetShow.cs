using System;

class AlphabetShow
{
    static void Main()
    {
        char[] letters = new char[26];
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = (char)(i + 65);
        }

        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < letters.Length; j++)
            {
                if (word[i] == letters[j])
                {
                    Console.WriteLine(j);
                }
            }
        }
    }
}
