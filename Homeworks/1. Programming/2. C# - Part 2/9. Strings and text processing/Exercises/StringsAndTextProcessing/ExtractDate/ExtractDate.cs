using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static bool IsDate(string input)
    {
        bool isWordCharacter = true;

        string availableChars = "0123456789.";

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
        string input = "Please contact us by phone (+359 222 222 222) or by email at exa_mple@abv.bg 22.04.2013 or at baj.ivan@yahoo.co.uk 22.03.2013. This is not email: 45.45.2012. This also: 1.1.2001 @telerik.com. Neither this: a@a.b.";

        string[] separatedInput = input.Split(' ');

        for (int i = 0; i < separatedInput.Length; i++)
        {
            string currentWord = separatedInput[i];

            if (currentWord[currentWord.Length - 1] == '.' || currentWord[currentWord.Length - 1] == ',' || currentWord[currentWord.Length - 1] == '!' || currentWord[currentWord.Length - 1] == '?' || currentWord[currentWord.Length - 1] == ':' || currentWord[currentWord.Length - 1] == ';')
                separatedInput[i] = currentWord.Remove(currentWord.Length - 1);
        }

        for (int i = 0; i < separatedInput.Length; i++)
        {
            if (!IsDate(separatedInput[i]))
            {
                continue;
            }

            IFormatProvider culture = new CultureInfo("de-DE", true);
            DateTime Date;

            try
            {
                Date = DateTime.Parse(separatedInput[i], culture);
            }
            catch (Exception)
            {
                continue;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            Console.WriteLine(Date.ToString().Substring(0, 10));
        }
    }
}

