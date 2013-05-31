using System;

class BitExchange
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
        uint firstMaskAndInteger;
        uint secondMaskAndInteger;
        uint firstBit;
        uint secondBit;
        uint temp;
        for (int i = 0; i < 3; i++)
        {
            firstMask = 1 << (i + 3);
            secondMask = 1 << (i + 24);
            firstMaskAndInteger = (uint)firstMask & integer;
            secondMaskAndInteger = (uint)secondMask & integer;
            firstBit = firstMaskAndInteger >> (i + 3);
            secondBit = secondMaskAndInteger >> (i + 24);
            temp = firstBit;
            firstBit = secondBit;
            secondBit = temp;
            if (firstBit == 0)
            {
                firstMask = ~(1 << (i + 3));
                integer &= (uint)firstMask;
            }
            if (firstBit == 1)
            {
                firstMask = 1 << (i + 3);
                integer |= (uint)firstMask;
            }
            if (secondBit == 0)
            {
                secondMask = ~(1 << (i + 24));
                integer &= (uint)secondMask;
            }
            if (secondBit == 1)
            {
                secondMask = 1 << (i + 24);
                integer |= (uint)secondMask;
            }
        }
        Console.WriteLine("Result: {0}.", integer);
        Console.WriteLine("Result in binary: " + (Convert.ToString(integer, 2).PadLeft(32, '0')) + ".");
    }
}