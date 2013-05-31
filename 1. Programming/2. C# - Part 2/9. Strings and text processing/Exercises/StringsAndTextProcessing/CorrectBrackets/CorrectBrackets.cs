using System;
using System.Text;

class CorrectBrackets
{
    static void Main(string[] args)
    {
        string input = "(((a+b)/5)-d)";
        int counter = 0;
        bool bracketsAreCorrect = true;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                counter++;
            }
            else if (input[i] == ')')
            {
                counter--;
            }

            if (counter < 0)
            {
                bracketsAreCorrect = false;
                break;
            }
        }

        if (!bracketsAreCorrect)
        {
            Console.WriteLine("Brackets are not correct!");
        }
        else if (counter == 0)
        {
            Console.WriteLine("Brackets are correct!");
        }
        else
        {
            Console.WriteLine("Brackets are not correct!");
        }
    }
}
