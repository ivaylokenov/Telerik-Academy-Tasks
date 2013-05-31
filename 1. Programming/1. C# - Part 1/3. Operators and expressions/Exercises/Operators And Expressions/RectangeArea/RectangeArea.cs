using System;

class RectangeArea
{
    static void Main()
    {
        decimal width;
        decimal height;
        decimal area;
        Console.Write("Enter ractangle width in metres: ");
        string strRead = Console.ReadLine();
        bool parseSuccess = decimal.TryParse(strRead, out width);
        while (width <= 0 || parseSuccess == false)
        {
            Console.Write("Rectangle width is invalid. It should be > 0. Try again: ");
            strRead = Console.ReadLine();
            parseSuccess = decimal.TryParse(strRead, out width);
        }
        Console.Write("Enter rectangle height in metres: ");
        strRead = Console.ReadLine();
        parseSuccess = decimal.TryParse(strRead, out height);
        while (height <= 0 || parseSuccess == false)
        {
            Console.Write("Rectangle height is invalid. It should be > 0. Try again: ");
            strRead = Console.ReadLine();
            parseSuccess = decimal.TryParse(strRead, out height);
        }
        area = width * height;
        Console.WriteLine("Your rectangle's area is: {0} square metres.", area);
    }
}
