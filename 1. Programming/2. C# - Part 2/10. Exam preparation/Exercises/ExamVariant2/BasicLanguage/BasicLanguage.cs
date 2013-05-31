using System;
using System.Collections.Generic;
using System.Text;

class BasicLanguage
{
    static void Main()
    {
        //BGCoder: 80/100

        StringBuilder input = new StringBuilder();
        while (true)
        {
            string line = Console.ReadLine();

            input.Append(line);
            input.Append("\n\r");

            if (line.EndsWith("EXIT;"))
            {
                break;
            }
        }

        string[] fullInput = input.ToString().Split(new char[] { ')' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < fullInput.Length; i++)
        {
            string currentString = fullInput[i].TrimStart();

            if (currentString[0] == ';')
            {
                currentString = currentString.Remove(0, 1);
            }
            while (currentString.StartsWith("\n\r"))
            {
                currentString = currentString.Remove(0, 2);
            }

            fullInput[i] = currentString;
        }

        int printCounter = 1;
        bool inPrint = false;

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < fullInput.Length; i++)
        {
            string currentString = fullInput[i];

            if (currentString.Substring(0, 3) == "FOR")
            {
                inPrint = false;
                int bracketIndex = currentString.IndexOf('(');

                string forCycle = currentString.Substring(bracketIndex + 1);

                int commaIndex = forCycle.IndexOf(',');

                if (commaIndex == -1)
                {
                    string forCycleParameter = forCycle.Trim();

                    printCounter *= int.Parse(forCycleParameter);
                }
                else
                {
                    string[] forCycleParameters = forCycle.Split(',');

                    forCycleParameters[0] = forCycleParameters[0].Trim();
                    forCycleParameters[1] = forCycleParameters[1].Trim();

                    printCounter *= (int.Parse(forCycleParameters[1]) - int.Parse(forCycleParameters[0]) + 1);
                }
            }

            if (currentString.Substring(0, 5) == "PRINT")
            {
                inPrint = true;
                int bracketIndex = currentString.IndexOf('(');

                for (int j = 0; j < printCounter; j++)
                {
                    output.Append(currentString.Substring(bracketIndex + 1));
                }

                printCounter = 1;
            }



            if (currentString.Substring(0, 5) == "EXIT")
            {
                break;
            }

        }

        Console.WriteLine(output.ToString());
    }
}
