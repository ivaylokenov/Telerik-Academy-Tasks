using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class SubstringStartToFinish
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\WordStartToFinish.txt");
        StringBuilder result = new StringBuilder();

        using (readFile)
        {
            string allLines = readFile.ReadToEnd();
            for (int i = 0; i < allLines.Length - 6; i++)
            {
                if (allLines.Substring(i, 7) == " start ")
                {
                    result.Append(" finish ");
                    i += 6;
                }
                else
                {
                    result.Append(allLines[i]);
                }
            }
        }

        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\WordStartToFinish.txt");

        using (writeFile)
        {
            writeFile.Write(result.ToString());
        }

        Console.WriteLine(@"Result was saved to TestFiles\WordStartToFinish.txt");
    }
}
