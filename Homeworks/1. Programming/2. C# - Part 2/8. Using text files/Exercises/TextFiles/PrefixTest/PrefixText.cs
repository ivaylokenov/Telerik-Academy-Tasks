using System;
using System.IO;
using System.Text;

class PrefixText
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\TextPrefix.txt");
        StringBuilder result = new StringBuilder();

        using (readFile)
        {
            string allLines = readFile.ReadToEnd();
            string[] separatedWords = allLines.Split(' ');

            for (int i = 0; i < separatedWords.Length; i++)
            {
                if (separatedWords[i].Length >= 4)
                {
                    if (separatedWords[i].Substring(0, 4) == "test")
                    {
                        separatedWords[i] = string.Empty;
                        result.Append(string.Empty);
                    }
                    else
                    {
                        result.Append(separatedWords[i] + " ");
                    }
                }
                else
                {
                    result.Append(separatedWords[i] + " ");
                }
            }
        }

        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\TextPrefix.txt");

        using (writeFile)
        {
            writeFile.Write(result.ToString());
        }

        Console.WriteLine(@"Result was saved to TestFiles\TextPrefix.txt");
    }
}
