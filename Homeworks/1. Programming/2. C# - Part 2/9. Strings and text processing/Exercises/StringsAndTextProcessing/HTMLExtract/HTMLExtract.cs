using System;
using System.IO;
using System.Text;

class HTMLExtract
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\..\TestFiles\TestHTML.html");

        Console.WriteLine("Extracting TestHTML.html...");

        using (reader)
        {
            string input = reader.ReadToEnd();

            int indexStartTitle = input.IndexOf("<title>");

            if (indexStartTitle >= 0)
            {
                int indexEndTitle = input.IndexOf("</title>");
                Console.Write("Title is: ");

                for (int i = indexStartTitle + 7; i < indexEndTitle; i++)
                {
                    Console.Write(input[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Body is: ");

            indexStartTitle = input.IndexOf("<body>");

            StringBuilder output = new StringBuilder();

            bool isTag = false;

            for (int i = indexStartTitle; i < input.Length; i++)
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

            Console.WriteLine(output.ToString().Trim());
        }

    }
}
