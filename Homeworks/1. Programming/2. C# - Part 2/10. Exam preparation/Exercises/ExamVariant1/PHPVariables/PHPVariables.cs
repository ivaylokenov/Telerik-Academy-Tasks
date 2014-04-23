using System;
using System.Collections.Generic;
using System.Text;

class PHPVariables
{
    static void Main()
    {
        //BGCoder: 80/100

        StringBuilder inputAll = new StringBuilder();
        while (true)
        {
            string input = Console.ReadLine().Trim();
            inputAll.Append(input);
            inputAll.Append("\n\r");
            if (input == "?>")
            {
                break;
            }
        }

        string phpCode = inputAll.ToString();

        List<string> variables = new List<string>();

        //variable in comment - NOT INCLUDE
        //variable in multiline comment - NOT INCLUDE

        bool inStringWithSingleQuote = false;
        bool inStringWithDoubleQuote = false;
        bool inSingleLineComment = false;
        bool inMultiLineComment = false;
        bool inVariable = false;

        StringBuilder variableConstructor = new StringBuilder();

        for (int i = 0; i < phpCode.Length; i++)
        {
            //single quote string
            if (inStringWithDoubleQuote == false && inStringWithSingleQuote == false && inSingleLineComment == false && inMultiLineComment == false && phpCode[i] == '\'')
            {
                inStringWithSingleQuote = true;
                continue;
            }

            if (inStringWithSingleQuote == true && phpCode[i] == '\'' && phpCode[i - 1] != '\\')
            {
                inStringWithSingleQuote = false;
                continue;
            }

            //double quote string
            if (inStringWithSingleQuote == false && inStringWithDoubleQuote == false && inSingleLineComment == false && inMultiLineComment == false && phpCode[i] == '\"')
            {
                inStringWithDoubleQuote = true;
                continue;
            }

            if (inStringWithDoubleQuote == true && phpCode[i] == '\"' && phpCode[i - 1] != '\\')
            {
                inStringWithDoubleQuote = false;
                continue;
            }

            //single line comment

            if (inStringWithSingleQuote == false && inStringWithDoubleQuote == false && inMultiLineComment == false && phpCode[i] == '#')
            {
                inSingleLineComment = true;
                continue;
            }

            if (inStringWithSingleQuote == false && inStringWithDoubleQuote == false && inMultiLineComment == false && phpCode[i] == '/' && i + 1 < phpCode.Length - 1 && phpCode[i + 1] == '/')
            {
                inSingleLineComment = true;
                i++;
                continue;
            }

            if (inSingleLineComment == true && phpCode[i] == '\n' && i < phpCode.Length - 1 && phpCode[i + 1] == '\r')
            {
                inSingleLineComment = false;
                i++;
                continue;
            }

            //multiline comment

            if (inStringWithSingleQuote == false && inStringWithDoubleQuote == false && inSingleLineComment == false && phpCode[i] == '/' && i + 1 < phpCode.Length - 1 && phpCode[i + 1] == '*')
            {
                inMultiLineComment = true;
                i++;
                continue;
            }

            if (inMultiLineComment == true && phpCode[i] == '*' && i + 1 < phpCode.Length - 1 && phpCode[i + 1] == '/')
            {
                inMultiLineComment = false;
                i++;
                continue;
            }

            //variable

            if (inSingleLineComment == false && inMultiLineComment == false)
            {
                if (inStringWithDoubleQuote == false && inStringWithSingleQuote== false && phpCode[i] == '$')
                {
                    inVariable = true;
                    continue;
                }
                else if ((inStringWithSingleQuote == true || inStringWithDoubleQuote == true) && phpCode[i] == '$' && phpCode[i-1] != '\\')
                {
                    inVariable = true;
                    continue;
                }
                else if ((inStringWithSingleQuote == true || inStringWithDoubleQuote == true) && phpCode[i] == '$' && phpCode[i - 1] == '\\' && phpCode[i-2] == '\\')
                {
                    inVariable = true;
                    continue;
                }
            }

            //variable constructor
            if (inVariable)
            {
                char ch = phpCode[i];

                if (char.IsDigit(ch) || char.IsLetter(ch) || ch == '_')
                {
                    variableConstructor.Append(phpCode[i]);
                }
                else
                {
                    inVariable = false;

                    if (variables.Contains(variableConstructor.ToString()))
                    {
                        variableConstructor.Clear();
                    }
                    else
                    {
                        variables.Add(variableConstructor.ToString());
                        variableConstructor.Clear();
                    }
                }
            }
        }

        variables.Sort(StringComparer.Ordinal);

        Console.WriteLine(variables.Count);

        for (int i = 0; i < variables.Count; i++)
        {
            Console.WriteLine(variables[i]);
        }
    }
}
