using System;
using System.Text;
using System.Collections.Generic;

class ChangeAnchorTag
{
    static void Main()
    {
        string input = @"<p>Please visit <a href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        
        string output = input.Replace(@"<a href=""", "[URL=");
        output = output.Replace("</a>", "[/URL]");

        int index = output.IndexOf("[URL=");

        while (index >= 0)
        {
            index = output.IndexOf(@""">", index + 1);

            output = output.Remove(index, 2);
            output = output.Insert(index, "]");

            index = output.IndexOf("[URL=", index + 1);
        }

        Console.WriteLine(output);
    }
}
