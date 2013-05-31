using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\LineNumbers.txt");
        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\ResultLineNumbers.txt");

        using (readFile)
        {
            using (writeFile)
            {
                string line = readFile.ReadLine();
                int lineNumber = 1;

                while (line != null)
                {
                    writeFile.WriteLine("{0}. " + line, lineNumber);
                    lineNumber++;
                    line = readFile.ReadLine();
                }
            }
        }

        Console.WriteLine(@"Text was saved to TestFiles\ResultLineNumbers.txt");
    }
}
