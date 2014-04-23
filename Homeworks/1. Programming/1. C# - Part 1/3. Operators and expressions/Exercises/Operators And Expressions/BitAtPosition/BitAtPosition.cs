using System;

class BitAtPosition
{
    static void Main()
    {
        int integer;
        int position;
        int mask;
        Console.Write("Enter number: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out integer);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out integer);
        }
        Console.WriteLine("You integer in binary: " + (Convert.ToString(integer, 2).PadLeft(32, '0')) + ".");
        Console.Write("Enter position: ");
        readStr = Console.ReadLine();
        parseSuccess = Int32.TryParse(readStr, out position);
        while (position < 0 || parseSuccess == false)
        {
            Console.Write("Your input is invalid. It should be >= 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out position);
        }
        mask = 1 << position;
        int maskAndInt = mask & integer;
        int bit = maskAndInt >> position;
        bool isOne = false;
        if (bit == 1)
        {
            isOne = true;
            Console.WriteLine("The bit at position {0} is {1}. Result is: {2}.", position, bit, isOne);
        }
        else
        {
            Console.WriteLine("The bit at position {0} is {1}. Result is: {2}.", position, bit, isOne);
        }
    }
}
