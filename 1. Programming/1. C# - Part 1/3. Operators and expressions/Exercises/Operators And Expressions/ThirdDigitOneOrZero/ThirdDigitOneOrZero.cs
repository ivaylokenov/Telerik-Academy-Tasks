using System;

class ThirdDigitOneOrZero
{
    static void Main()
    {
        int integer;
        Console.Write("Enter integer: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = Int32.TryParse(readStr, out integer);
        while (parseSuccess == false)
        {
            Console.Write("Your integer is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = Int32.TryParse(readStr, out integer);
        }
        Console.WriteLine("You integer in binary: " + (Convert.ToString(integer, 2).PadLeft(32, '0')) + ".");
        int mask = 1 << 3;
        int integerAndMask = integer & mask;
        int bit = integerAndMask >> 3;
        if (bit == 0)
        {
            Console.WriteLine("The 3rd bit from your integer is 0.");
        }
        else
        {
            Console.WriteLine("The 3rd bit from your integer is 1.");
        }
    }
}
