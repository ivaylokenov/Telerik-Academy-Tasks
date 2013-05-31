using System;
using System.Text;
using System.IO;

namespace Problem_1_CSharp_Clean_Code
{
    class Program
    {
        static void Main()
        {
            StringBuilder code = new StringBuilder();
            int linesCount = int.Parse(Console.ReadLine());

            bool inMultiLineComment = false;
            bool inString = false;
            bool inMultilineString = false;
            bool inSingleQuotedString = false;

            for (int i = 1; i <= linesCount; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < line.Length; j++)
                {
                    if (inMultilineString)
                    {
                        if (line[j] == '\"' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            code.Append("\"\"");
                            j++;
                            continue;
                        }
                    }
                    if (inString)
                    {
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\"')
                        {
                            code.Append("\\\"");
                            j++;
                            continue;
                        }
                        if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                        {
                            code.Append("\\\'");
                            j++;
                            continue;
                        }
                        if (line[j] == '\"' && !inSingleQuotedString)
                        {
                            inString = false;
                            inMultilineString = false;
                            code.Append('\"');
                            continue;
                        }
                        if (line[j] == '\'' && inSingleQuotedString)
                        {
                            inString = false;
                            inSingleQuotedString = false;
                            code.Append('\'');
                            continue;
                        }
                        code.Append(line[j]);
                        continue;
                    }

                    // Multiline comments
                    if (!inMultiLineComment && j + 1 < line.Length && line[j] == '/' && line[j + 1] == '*')
                    {
                        inMultiLineComment = true;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment && j + 1 < line.Length && line[j] == '*' && line[j + 1] == '/')
                    {
                        inMultiLineComment = false;
                        j++;
                        continue;
                    }
                    if (inMultiLineComment)
                    {
                        continue;
                    }

                    // One line comment
                    if (line[j] == '/' && j + 1 < line.Length && line[j + 1] == '/')
                    {
                        if (j + 2 >= line.Length || line[j + 2] != '/')
                        {
                            break;
                        }
                        else
                        {
                            // Inline documentation (///)
                            code.Append("///");
                            j += 2;
                            continue;
                        }
                    }

                    if (line[j] == '@' && j + 1 < line.Length && line[j + 1] == '\"')
                    {
                        inString = true;
                        inMultilineString = true;
                        j++;
                        code.Append("@\"");
                        continue;
                    }

                    if (line[j] == '\"')
                    {
                        inString = true;
                    }

                    if (line[j] == '\'')
                    {
                        inString = true;
                        inSingleQuotedString = true;
                    }


                    code.Append(line[j]);
                }   

                if (!inMultiLineComment) code.AppendLine();
            }

            StringReader sr = new StringReader(code.ToString());
            string lineToPrint = null;
            while ((lineToPrint = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(lineToPrint))
                {
                    Console.WriteLine(lineToPrint);
                }
            }
        }
    }
}
