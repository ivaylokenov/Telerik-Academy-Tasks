using System;
using System.Globalization;
using System.Threading;

class PerimeterAndArea
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Perimeter and area";
        string title = new string('-', 62);
        Console.WriteLine(title);
        Console.WriteLine("This program calculates the perimeter and the area of a circle");
        Console.WriteLine(title + "\n\r");
        Console.Write("Enter radius in centimeters: ");
        string readStr = Console.ReadLine();
        decimal radius;
        bool parseSuccess = decimal.TryParse(readStr, out radius);
        while (parseSuccess == false)
        {
            Console.WriteLine("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = decimal.TryParse(readStr, out radius);
        }
        decimal area = (decimal)Math.PI * radius * radius;
        decimal perimeter = 2 * (decimal)Math.PI * radius;
        Console.WriteLine("\n\rPerimeter of circle: {0,10:F2} centimeters.\n\rArea of circle: {1,15:F2} square centimeters.\n\r", perimeter, area);
    }
}
