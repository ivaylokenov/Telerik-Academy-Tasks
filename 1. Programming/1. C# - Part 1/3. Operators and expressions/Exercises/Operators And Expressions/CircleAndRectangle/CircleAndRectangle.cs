using System;

class CircleAndRectangle
{
    static void Main()
    {
        decimal pointX;
        decimal pointY;
        decimal circle_X = 1;
        decimal circle_Y = 1;
        decimal circle_radius = 3;
        decimal rect_left = -1;
        decimal rect_top = 1;
        decimal rect_width = 6;
        decimal rect_height = 2;
        Console.Write("Enter coordinate X: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = decimal.TryParse(readStr, out pointX);
        while (parseSuccess == false)
        {
            Console.Write("Your input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out pointX);
        }
        Console.Write("Enter coordinate Y: ");
        readStr = Console.ReadLine();
        parseSuccess = decimal.TryParse(readStr, out pointY);
        while (parseSuccess == false)
        {
            Console.Write("Yout input is invalid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out pointY);
        }
        bool isTrue = ((((pointX - circle_X) * (pointX - circle_X)) + ((pointY - circle_Y) * (pointY - circle_Y)) <= circle_radius * circle_radius) && ((pointX < rect_left) || (pointX > (rect_left + rect_width)) || (pointY > rect_top) || (pointY < (rect_top - rect_height))));
        if (isTrue == true)
        {
            Console.WriteLine("Your point is within the circle and out of the rectangle.");
        }
        else
        {
            Console.WriteLine("Your point is not within the circle or is within the rectangle.");
        }
    }
}
