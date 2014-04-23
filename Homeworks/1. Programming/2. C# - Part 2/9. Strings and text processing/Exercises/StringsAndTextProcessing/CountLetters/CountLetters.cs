using System;
using System.Text;

class CountLetters
{
    static void Main()
    {
        string letters = "abcdefghijklmnopqrstuvwqxyz";
        int[] countLetters = new int[letters.Length];

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            int index = letters.IndexOf((input[i].ToString()).ToLower());

            if (index >= 0)
            {
                countLetters[index]++;
            }
        }

        for (int i = 0; i < countLetters.Length; i++)
        {
            if (countLetters[i] != 0)
            {
                Console.Write(letters[i] + ": " + countLetters[i] + " times\n\r");
            }
        }
    }
}
