using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CSharpCleanCode
{
    static void Main()
    {
        //BGCoder: 60/100

        int N = int.Parse(Console.ReadLine());

        StringBuilder input = new StringBuilder();

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();

            input.Append(line);
            input.Append("\n\r");
        }

        string allInput = input.ToString().Remove(input.Length - 2);

        bool inSingleLineComment = false;
        bool inMultilineComment = false;
        bool inString = false;
        bool inPredefinedString = false;

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < allInput.Length; i++)
        {
            //single line string
            if (inSingleLineComment == false && inMultilineComment == false && inString == false && inPredefinedString == false && allInput[i] == '\"' && i - 1 >= 0 && allInput[i - 1] != '@')
            {
                inString = true;
                output.Append(allInput[i]);
                continue;
            }

            if (inString == true && allInput[i] == '\"' && allInput[i - 1] != '\\')
            {
                inString = false;
                output.Append(allInput[i]);
                continue;
            }

            //predefined string
            if (inSingleLineComment == false && inMultilineComment == false && inString == false && inPredefinedString == false && allInput[i] == '@' && i + 1 < allInput.Length && allInput[i + 1] == '\"')
            {
                inPredefinedString = true;
                output.Append(allInput[i]);
                i++;
                output.Append(allInput[i]);
                continue;
            }

            if (inPredefinedString == true && allInput[i] == '\"' && i + 1 < allInput.Length && allInput[i + 1] == '\"')
            {
                output.Append(allInput[i]);
                i++;
                output.Append(allInput[i]);
                continue;
            }

            if (inPredefinedString == true && allInput[i] == '\"' && i + 1 < allInput.Length && allInput[i + 1] != '\"')
            {
                inPredefinedString = false;
                output.Append(allInput[i]);
                continue;
            }

            //singleline comment
            if (inString == false && inPredefinedString == false && inMultilineComment == false && allInput[i] == '/' && i + 1 < allInput.Length && allInput[i + 1] == '/' && i + 2 < allInput.Length && allInput[i + 2] != '/' && i - 1 >= 0 && allInput[i-1] != '\'')
            {
                inSingleLineComment = true;
                i++;
                continue;
            }

            if (inSingleLineComment == true && allInput[i] != '\n' && i + 1 < allInput.Length && allInput[i + 1] != '\r')
            {
                continue;
            }

            if (inSingleLineComment == true && allInput[i] == '\n' && i + 1 < allInput.Length && allInput[i + 1] == '\r')
            {
                inSingleLineComment = false;
                output.Append(allInput[i]);
                i++;
                output.Append(allInput[i]);
                continue;
            }

            //multiline comment
            if (inSingleLineComment == false && inMultilineComment == false && inString == false && inPredefinedString == false && allInput[i] == '/' && i + 1 < allInput.Length && allInput[i + 1] == '*')
            {
                inMultilineComment = true;
                i++;
                continue;
            }

            if (inMultilineComment == true && allInput[i] == '*' && i + 1 < allInput.Length && allInput[i + 1] == '/')
            {
                inMultilineComment = false;
                i++;
                continue;
            }
            else if (inMultilineComment == true)
            {
                continue;
            }

            output.Append(allInput[i]);
        }

        string[] result = output.ToString().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < result.Length; i++)
        {
            string currentString = result[i].TrimEnd();
            if (currentString != string.Empty)
            {
                Console.WriteLine(currentString);
            }
        }
    }
}