using System;
using System.Collections.Generic;
using System.IO;

class CompareTwoTextFiles
{
    static void Main()
    {
        StreamReader readFirstFile = new StreamReader(@"..\..\..\TestFiles\CompareFile1.txt");
        StreamReader readSecondFile = new StreamReader(@"..\..\..\TestFiles\CompareFile2.txt");

        int sameLines = 0;
        int differentLines = 0;

        string lineFirst = string.Empty;
        string lineSecond = string.Empty;

        using (readFirstFile)
        {
            using (readSecondFile)
            {
                lineFirst = readFirstFile.ReadLine();
                lineSecond = readSecondFile.ReadLine();
                while (lineFirst != null)
                {
                    if (lineFirst == lineSecond)
                    {
                        sameLines++;
                    }
                    else
                    {
                        differentLines++;
                    }

                    lineFirst = readFirstFile.ReadLine();
                    lineSecond = readSecondFile.ReadLine();
                }
            }
        }

        Console.WriteLine("Same lines number: {0}.\n\rDifferent lines number: {1}.", sameLines, differentLines);
    }
}