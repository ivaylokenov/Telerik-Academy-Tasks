using System;
using System.Text;

class SentencesWithWords
{
    static void Main()
    {
        string givenWord = "in";
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string[] sentences = text.Split('.');

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < sentences.Length; i++)
        {
            int index = sentences[i].IndexOf(givenWord);

            while (index >= 0 && sentences[i].Length > givenWord.Length)
            {
                string currentSentence = sentences[i];

                if (currentSentence[index - 1] == ' ' || currentSentence[index - 1] == '.' || currentSentence[index - 1] == ',')
                {
                    result.Append(sentences[i].TrimStart());
                    result.Append(".");
                    Console.WriteLine(result.ToString());
                    result.Clear();
                }

                index = sentences[i].IndexOf(givenWord, index + 1);
            }
        }
    }
}
