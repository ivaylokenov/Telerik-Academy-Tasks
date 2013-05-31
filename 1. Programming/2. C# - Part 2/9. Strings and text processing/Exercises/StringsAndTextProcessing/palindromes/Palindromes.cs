using System;
using System.Text;

class Palindromes
{
    static void Main()
    {
        string input = "nekvi dumi eto edin palindrom: abba, eto o6te edin: malam, i posleden: tuput.";

        string[] separatedInput = input.Split(' ');

        for (int i = 0; i < separatedInput.Length; i++)
        {
            string currentWord = separatedInput[i];

            if (currentWord[currentWord.Length - 1] == '.' || currentWord[currentWord.Length - 1] == ',' || currentWord[currentWord.Length - 1] == '!' || currentWord[currentWord.Length - 1] == '?' || currentWord[currentWord.Length - 1] == ':' || currentWord[currentWord.Length - 1] == ';')
                separatedInput[i] = currentWord.Remove(currentWord.Length - 1);
        }

        for (int i = 0; i < separatedInput.Length; i++)
        {
            string currentWord = separatedInput[i];
            bool isPalindrome = true;

            for (int j = 0, k = currentWord.Length - 1; j < currentWord.Length/2; j++, k--)
            {
                if (currentWord[j] != currentWord[k])
                {
                    isPalindrome = false;
                }
            }

            if (isPalindrome & currentWord.Length > 1)
            {
                Console.WriteLine(currentWord);
            }
        }
    }
}
