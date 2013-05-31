using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\DeleteOddLines.txt");
        StringBuilder result = new StringBuilder();

        using (readFile)
        {
            string line = readFile.ReadLine();
            int counter = 1;

            while (line != null)
            {
                if (counter % 2 == 0)
                {
                    result.Append(line + "\n\r");
                }

                line = readFile.ReadLine();
                counter++;
            }
        }

        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\ResultDeleteOddLines.txt");

        using (writeFile)
        {
            writeFile.Write(result.ToString());
        }

        Console.WriteLine(@"Result was saved to TestFiles\ResultDeleteOddLines.txt");
    }
}
