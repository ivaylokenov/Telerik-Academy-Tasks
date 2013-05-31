using System;
using System.Collections.Generic;
using System.IO;

class SortListOfStrings
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\Strings.txt");
        List<string> readNames = new List<string>();

        using (readFile)
        {
            string line = readFile.ReadLine();

            while (line != null)
            {
                readNames.Add(line);
                line = readFile.ReadLine();
            }
        }

        readNames.Sort();

        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\SortedStrings.txt");

        using (writeFile)
        {
            for (int i = 0; i < readNames.Count; i++)
            {
                writeFile.WriteLine(readNames[i]);
            }
        }

        Console.WriteLine(@"Sorted names were written to TestFiles\SortedStrings.txt");
    }
}
