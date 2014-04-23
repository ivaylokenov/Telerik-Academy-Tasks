using System;
using System.Text;

class Upcase
{
    static void Main()
    {
        string openTag = "<upcase>";
        string closeTag = "</upcase>";
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        StringBuilder result = new StringBuilder();

        bool isTag = false;
        int i = 0;

        for (i = 0; i < text.Length - closeTag.Length + 1; i++)
        {
            if (text.Substring(i, 8) == openTag)
            {
                isTag = true;
                i += 7;
                continue;
            }
            else if (text.Substring(i, 9) == closeTag)
            {
                isTag = false;
                i += 8;
                continue;
            }

            if (!isTag)
            {
                result.Append(text[i]);
            }
            else 
            {
                result.Append(text[i].ToString().ToUpper());
            }
        }

        for (int j = i; j < text.Length; j++)
        {
            result.Append(text[j]);
        }

        Console.WriteLine(result.ToString());
    }
}
