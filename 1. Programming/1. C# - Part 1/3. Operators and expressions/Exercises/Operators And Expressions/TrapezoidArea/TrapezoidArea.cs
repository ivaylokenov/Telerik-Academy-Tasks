using System;

class TrapezoidArea
{
    static void Main()
    {
        decimal sideA;
        decimal sideB;
        decimal height;
        decimal trapArea;
        Console.Write("Enter side A in meters: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = decimal.TryParse(readStr, out sideA);
        while (sideA <= 0 || parseSuccess == false)
        {
            Console.Write("Your input is invalid. It should be > 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out sideA);
        }
        Console.Write("Enter side B in meters: ");
        readStr = Console.ReadLine();
        parseSuccess = decimal.TryParse(readStr, out sideB);
        while (sideB <= 0 || parseSuccess == false)
        {
            Console.Write("Your input is invalid. It should be > 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out sideB);
        }
        Console.Write("Enter height in meters: ");
        readStr = Console.ReadLine();
        parseSuccess = decimal.TryParse(readStr, out height);
        while (height <= 0 || parseSuccess == false)
        {
            Console.Write("Your input is invalid. It should be > 0. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out height);
        }
        trapArea = ((sideA + sideB) / 2) * height;
        Console.WriteLine("Your trapezoid's area is: {0} square meters", trapArea);
    }
}
