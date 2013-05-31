using System;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        string[] forbiddenWords = {"PHP", "CLR", "Microsoft"};
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            string word = forbiddenWords[i];
            int index = text.IndexOf(word);

            string replace = new string('*', word.Length);

            while (index >= 0)
            {
                text = text.Replace(word, replace);
                index = text.IndexOf(word, index + 1);
            }
        }

        Console.WriteLine(text);
    }
}
