using System;

class HoldTheValue
{
    static void Main()
    {
        int number;
        int position;
        int bitValue;
        Console.Write("Enter number: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out number);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out number);
        }
        Console.WriteLine("You integer in binary: " + (Convert.ToString(number, 2).PadLeft(32, '0')) + ".");
        Console.Write("Enter position: ");
        readStr = Console.ReadLine();
        parseSuccess = Int32.TryParse(readStr, out position);
        while (position < 0 || parseSuccess == false)
        {
            Console.Write("Your input is invalid. It should be >= 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out position);
        }
        Console.Write("Enter bit value: ");
        readStr = Console.ReadLine();
        parseSuccess = Int32.TryParse(readStr, out bitValue);
        while (bitValue != 0 && bitValue != 1 && parseSuccess == false)
        {
            Console.Write("Bit value can only be 0 or 1. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out bitValue);
        }
        int mask;
        int maskAndInt;
        if (bitValue == 0)
        {
            mask = ~(1 << position);
            maskAndInt = mask & number;
        }
        else
        {
            mask = 1 << position;
            maskAndInt = mask | number;
        }
        Console.WriteLine("Result: {0}.", maskAndInt);
        Console.WriteLine("Result in binary: " + (Convert.ToString(maskAndInt, 2).PadLeft(32, '0')) + ".");
    }
}
