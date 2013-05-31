using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static bool isWord(string input)
    {
        bool isWordCharacter = true;

        string availableChars = "0123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM@.-_";

        for (int i = 0; i < input.Length; i++)
        {
            int index = availableChars.IndexOf(input[i]);

            if (index < 0)
            {
                isWordCharacter = false;
                break;
            }
        }

        return isWordCharacter;
    }

    static void Main()
    {
        //I assume identifier is not less than 6 characters, host is not less than one character and domain is not less than two characters like a normal e-mail
        string input = "Please contact us by phone (+359 222 222 222) or by email at exa_mple@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
        
        string[] separatedInput = input.Split(' ');

        for (int i = 0; i < separatedInput.Length; i++)
        {
            string currentWord = separatedInput[i];

            if (currentWord[currentWord.Length - 1] == '.' || currentWord[currentWord.Length - 1] == ',' || currentWord[currentWord.Length - 1] == '!' || currentWord[currentWord.Length - 1] == '?' || currentWord[currentWord.Length - 1] == ':' || currentWord[currentWord.Length - 1] == ';')
            separatedInput[i] = currentWord.Remove(currentWord.Length - 1);
        }

        bool hasIdentifier = false;
        bool hasHostAndDomain = false;

        for (int i = 0; i < separatedInput.Length; i++)
        {
            if (!isWord(separatedInput[i]))
            {
                continue;
            }

            int indexAt = separatedInput[i].IndexOf("@");

            if (indexAt > 5)
            {
                hasIdentifier = true;
            }
            
            int indexDot = separatedInput[i].IndexOf(".", indexAt + 1);

            if (indexDot > indexAt + 1)
            {
                hasHostAndDomain = true;
            }

            if (hasIdentifier & hasHostAndDomain)
            {
                if ((separatedInput[i].Substring(indexDot, separatedInput[i].Length - indexDot - 1)).Length > 1)
                {
                    Console.WriteLine(separatedInput[i]);
                }
            }

            hasIdentifier = false;
            hasHostAndDomain = false;
        }
    }
}
