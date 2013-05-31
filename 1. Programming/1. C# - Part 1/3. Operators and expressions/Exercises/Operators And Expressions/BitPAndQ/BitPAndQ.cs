using System;

class BitPAndQ
{
    static void Main()
    {
        uint integer;
        Console.Write("Enter positive number: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = UInt32.TryParse(readStr, out integer);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid: ");
            readStr = Console.ReadLine();
            parseSuccess = UInt32.TryParse(readStr, out integer);
        }
        Console.WriteLine("You integer in binary: " + (Convert.ToString(integer, 2).PadLeft(32, '0')) + ".");
        int firstMask;
        int secondMask;
        int firstPosition;
        Console.Write("Enter first position: ");
        readStr = Console.ReadLine();
        parseSuccess = Int32.TryParse(readStr, out firstPosition);
        while (firstPosition < 0 || parseSuccess == false)
        {
            Console.Write("Position is invalid. It should be >= 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out firstPosition);
        }
        int secondPosition;
        Console.Write("Enter second position: ");
        readStr = Console.ReadLine();
        parseSuccess = Int32.TryParse(readStr, out secondPosition);
        while (secondPosition < 0 || parseSuccess == false)
        {
            Console.Write("Position is invalid. It should be >= 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out secondPosition);
        }
        int k;
        Console.Write("Enter number of changed bits: ");
        readStr = Console.ReadLine();
        parseSuccess = Int32.TryParse(readStr, out k);
        while (k <= 0 || parseSuccess == false)
        {
            Console.Write("Number is invalid. It should be > 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out k);
        }
        uint firstMaskAndInteger;
        uint secondMaskAndInteger;
        uint firstBit;
        uint secondBit;
        uint temp;
        for (int i = 0; i < k; i++)
        {
            firstMask = 1 << (i + firstPosition);
            secondMask = 1 << (i + secondPosition);
            firstMaskAndInteger = (uint)firstMask & integer;
            secondMaskAndInteger = (uint)secondMask & integer;
            firstBit = firstMaskAndInteger >> (i + firstPosition);
            secondBit = secondMaskAndInteger >> (i + secondPosition);
            temp = firstBit;
            firstBit = secondBit;
            secondBit = temp;
            if (firstBit == 0)
            {
                firstMask = ~(1 << (i + firstPosition));
                integer &= (uint)firstMask;
            }
            if (firstBit == 1)
            {
                firstMask = 1 << (i + firstPosition);
                integer |= (uint)firstMask;
            }
            if (secondBit == 0)
            {
                secondMask = ~(1 << (i + secondPosition));
                integer &= (uint)secondMask;
            }
            if (secondBit == 1)
            {
                secondMask = 1 << (i + secondPosition);
                integer |= (uint)secondMask;
            }
        }
        Console.WriteLine("Result: {0}.", integer);
        Console.WriteLine("Result in binary: " + (Convert.ToString(integer, 2).PadLeft(32, '0')) + ".");
    }
}
