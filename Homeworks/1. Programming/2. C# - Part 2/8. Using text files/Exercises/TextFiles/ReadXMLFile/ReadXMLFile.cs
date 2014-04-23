using System;
using System.IO;
using System.Text;

class ReadXMLFile
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\XMLFile.xml");
        string input = string.Empty;
        StringBuilder output = new StringBuilder();

        using (readFile)
        {
            input = readFile.ReadToEnd();
        }

        bool isTag = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '<')
            {
                isTag = true;
            }

            if (!isTag)
            {
                output.Append(input[i]);
            }

            if (input[i] == '>')
            {
                isTag = false;
            }
        }

        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\XMLFileResult.txt");

        using (writeFile)
        {
            writeFile.WriteLine(output.ToString());
        }

        Console.WriteLine(@"Result was saved to TestFiles\XMLFileResult.txt");
    }
}
