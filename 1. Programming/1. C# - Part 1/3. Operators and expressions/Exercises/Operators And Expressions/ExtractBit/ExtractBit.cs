using System;

class ExtractBit
{
    static void Main()
    {
        int integer;
        int position;
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
        int mask = 1 << position;
        int maskAndInteger = mask & integer;
        int bit = maskAndInteger >> position;
        Console.WriteLine("Bit at position {0} is {1}.", position, bit);
    }
}
