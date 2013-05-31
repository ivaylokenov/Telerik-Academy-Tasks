using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\OddLines.txt");

        using (readFile)
        {
            string line = readFile.ReadLine();
            int counter = 1;

            while (line != null)
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine(line);
                }

                line = readFile.ReadLine();
                counter++;
            }
        }
    }
}
