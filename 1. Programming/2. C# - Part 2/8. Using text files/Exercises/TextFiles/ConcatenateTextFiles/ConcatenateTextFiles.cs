using System;
using System.IO;

class ConcatenateTextFiles
{
    static void Main()
    {
        StreamReader readFirstFile = new StreamReader(@"..\..\..\TestFiles\Concatenate1.txt");
        StreamReader readSecondFile = new StreamReader(@"..\..\..\TestFiles\Concatenate2.txt");
        string textFromFirstFile = string.Empty;
        string textFromSecondFile = string.Empty;

        using (readFirstFile)
        {
            textFromFirstFile = readFirstFile.ReadToEnd();
            Console.WriteLine("First text file:\n\r{0}", textFromFirstFile);
        }

        using (readSecondFile)
        {
            textFromSecondFile = readSecondFile.ReadToEnd();
            Console.WriteLine("\n\rSecond text file:\n\r{0}", textFromSecondFile);
        }

        string result = textFromFirstFile + textFromSecondFile;

        StreamWriter writeResult = new StreamWriter(@"..\..\..\TestFiles\ResultConcatenate.txt");

        using (writeResult)
        {
            writeResult.Write(result);
        }

        Console.WriteLine(@"Files were concatenated into TestFiles\ResultConcatenate.txt");
    }
}
