using System;
using System.Text;

class SubstringInText
{
    static void Main()
    {
        string substring = "in";
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        int output = 0;

        for (int i = 0; i < text.Length - substring.Length + 1; i++)
        {
            StringBuilder fromText = new StringBuilder();

            for (int j = 0; j < substring.Length; j++)
			{
                fromText.Append(text[i + j]);			 
			}

            int result = string.Compare(substring, fromText.ToString(), true);

            if (result == 0)
            {
                output++;
            }
        }

        Console.WriteLine("Output: {0}.", output);
    }
}
