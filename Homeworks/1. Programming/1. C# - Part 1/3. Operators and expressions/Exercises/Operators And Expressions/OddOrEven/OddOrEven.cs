using System;

class OddOrEven
{
    static void Main()
    {
        int integer = 0;
        string readStr;
        Console.Write("Enter number: ");
        readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out integer);
        while (parseSuccess == false)
        {
            Console.Write("Your number is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out integer);
        }
        bool oddOrEven = (integer % 2 == 0);
        if (oddOrEven == true)
        {
            Console.WriteLine("Your integer is even.");
        }
        else
        {
            Console.WriteLine("Your integer is odd.");
        }
    }
}