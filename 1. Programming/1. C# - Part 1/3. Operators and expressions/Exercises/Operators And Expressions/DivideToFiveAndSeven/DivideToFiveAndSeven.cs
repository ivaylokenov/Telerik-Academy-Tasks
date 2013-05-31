using System;

class DivideToFiveAndSeven
{
    static void Main()
    {
        int integer;
        Console.Write("Enter number: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out integer);
        while (parseSuccess == false)
        {
            Console.Write("Your number is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out integer);
        }
        bool canBeDivided = ((integer % 5 == 0) && (integer % 7 == 0));
        if (canBeDivided == true)
        {
            Console.WriteLine("Your integer can be divided to 5 and 7 without reminder.");
        }
        else
        {
            Console.WriteLine("Your integer cannot be divided to 5 and 7 without remainder.");
        }
    }
}