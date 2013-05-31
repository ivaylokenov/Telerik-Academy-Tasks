using System;
using System.Text;

namespace Problem_1_Basic_Language
{
    class Program
    {
        static void Main()
        {
            StringBuilder inputCode = new StringBuilder();
            while(true)
            {
                string line = Console.ReadLine();
                inputCode.AppendLine(line);
                if (line.EndsWith("EXIT;")) break;
            }

            BasicLanguageExecutor parser = new BasicLanguageExecutor();
            parser.ExecuteCode(inputCode.ToString());
            Console.WriteLine(parser.GetOutput());
        }
    }

    class BasicLanguageExecutor
    {
        private readonly StringBuilder output;

        public BasicLanguageExecutor()
        {
            output = new StringBuilder();
        }

        public string GetOutput()
        {
            return output.ToString();
        }

        private void ExecutePrint(long count, string outputString)
        {
            if (outputString.Length == 0) // optimization
            {
                return;
            }
            if (outputString.Length == 1) // optimization
            {
                output.Append(new string(outputString[0], (int)count));
            }
            else
            {
                for (int i = 1; i <= (int)count; i++)
                {
                    output.Append(outputString);
                }
            }
        }

        public void ExecuteCode(string code)
        {
            code = code.Trim(); // optimization of whitespaces
            long totalIterationsCount = 1;
            for (int i = 0; i < code.Length; i++)
            {
                char ch = code[i];
                if (ch == 'P') // PRINT(...);
                {
                    int startOfTheOutputText = code.IndexOf('(', i) + 1;
                    int endOfTheOutputText = code.IndexOf(')', i);
                    string textToOutput = code.Substring(startOfTheOutputText, endOfTheOutputText - startOfTheOutputText);

                    ExecutePrint(totalIterationsCount, textToOutput);

                    i = endOfTheOutputText + 1;
                    totalIterationsCount = 1;
                }
                else if (ch == 'F') // FOR(...)
                {
                    int startOfTheForParams = code.IndexOf('(', i) + 1;
                    int endOfTheForParams = code.IndexOf(')', i);
                    if (totalIterationsCount == 0) // optimization
                    {
                        i = endOfTheForParams;
                        continue;
                    }
                    string forParams = code.Substring(startOfTheForParams, endOfTheForParams - startOfTheForParams).Trim();
                    if (forParams.Contains(",")) // FOR(a, b)
                    {
                        string[] forParamsAsStrings = forParams.Split(',');
                        int a = int.Parse(forParamsAsStrings[0]);
                        int b = int.Parse(forParamsAsStrings[1]);
                        int currentForCount = b - a + 1;
                        totalIterationsCount *= currentForCount;
                    }
                    else // FOR(a)
                    {
                        int currentForCount = int.Parse(forParams);
                        totalIterationsCount *= currentForCount;
                    }
                    i = endOfTheForParams;
                }
                else if (ch == 'E') // EXIT;
                {
                    break;
                }
                else // ignore white spaces
                {
                    continue;
                }
            }
        }
    }
}
