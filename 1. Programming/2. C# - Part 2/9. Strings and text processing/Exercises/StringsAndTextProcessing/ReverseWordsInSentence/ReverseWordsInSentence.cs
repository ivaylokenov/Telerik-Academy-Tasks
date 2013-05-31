using System;
using System.Text;

class ReverseWordsInSentence
{
    static void Main()
    {
        string input = "C# is not C++, not PHP and not Delphi, not HTML and not CSS!";

        char endOfSentence = input[input.Length - 1];

        input = input.Remove(input.Length - 1);

        input = input.Insert(0, " ");

        string[] splitByCommas = input.Split(',');

        StringBuilder result = new StringBuilder();

        for (int i = splitByCommas.Length - 1; i >= 0; i--)
        {
            string[] words = splitByCommas[i].Split(' ');

            for (int j = words.Length - 1; j >= 0; j--)
            {
                result.Append(words[j]);

                if (j != 0)
                {
                    result.Append(' ');
                }
            }

            result.Remove(result.Length - 1, 1);
            result.Append(", ");
        }

        string output = result.ToString();
        output = output.TrimEnd();
        output = output.Remove(output.Length - 1);
        output = output.TrimEnd();

        Console.WriteLine(output + endOfSentence.ToString());
    }
}
