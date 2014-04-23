using System;

class WithinACircle
{
    static void Main()
    {
        decimal pointX;
        decimal pointY;
        decimal circle_radius = 5;
        Console.Write("Enter X coordinate of your point: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = decimal.TryParse(readStr, out pointX);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out pointX);
        }
        Console.Write("Enter Y coordinate of your point: ");
        readStr = Console.ReadLine();
        parseSuccess = decimal.TryParse(readStr, out pointY);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out pointY);
        }
        bool isWithin = ((pointX * pointX) + (pointY * pointY) <= circle_radius * circle_radius);
        if (isWithin == true)
        {
            Console.WriteLine("Your point is within the circle (0,0,5).");
        }
        else
        {
            Console.WriteLine("Your point is not within the circle (0,0,5).");
        }
    }
}
