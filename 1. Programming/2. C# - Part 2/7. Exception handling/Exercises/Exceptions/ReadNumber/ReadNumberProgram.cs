using System;

class ReadNumberProgram
{
    static int counter = 0;

    static string ReturnTextFromNumber(int number)
    {
        string result = string.Empty;

        switch (number)
        {
            case 1: result = "first"; break;
            case 2: result = "second"; break;
            case 3: result = "third"; break;
            case 4: result = "forth"; break;
            case 5: result = "fifth"; break;
            case 6: result = "sixth"; break;
            case 7: result = "seventh"; break;
            case 8: result = "eight"; break;
            case 9: result = "ninth"; break;
            case 10: result = "tenth"; break;
        }

        return result;
    }

    static int ReadNumber(int start, int end)
    {
        int number = 0;

        try
        {
            Console.Write("Enter {2} number between {0} and {1}: ", start, end, ReturnTextFromNumber(counter + 1));
            number = int.Parse(Console.ReadLine());
            counter++;

            if (counter == 10)
            {
                return number;
            }

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Your number is not valid!");
            return 0;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Your number is not in the limits!");
            return 0;
        }

        return ReadNumber(number, end);
    }

    static void Main()
    {
        ReadNumber(1, 100);
    }
}
