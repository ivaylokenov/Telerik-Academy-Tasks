using System;
using System.Threading;
using System.Globalization;

class QuadraticEquation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "Quadratic equation";
        string title = new string('-', 39);
        Console.WriteLine(title);
        Console.WriteLine("This program solves quadratic equations");
        Console.WriteLine(title + "\n\r");
        double a;
        double b;
        double c;
        Console.WriteLine("a*x^2 + b*x + c = 0\n\r");
        Console.Write("Enter a: ");
        string readStr = Console.ReadLine();
        bool parseSuccess = double.TryParse(readStr, out a);
        while (parseSuccess == false)
        {
            Console.Write("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = double.TryParse(readStr, out a);
        }
        Console.Write("Enter b: ");
        readStr = Console.ReadLine();
        parseSuccess = double.TryParse(readStr, out b);
        while (parseSuccess == false)
        {
            Console.Write("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = double.TryParse(readStr, out b);
        }
        Console.Write("Enter c: ");
        readStr = Console.ReadLine();
        parseSuccess = double.TryParse(readStr, out c);
        while (parseSuccess == false)
        {
            Console.Write("Your input is not valid. Try again: ");
            readStr = Console.ReadLine();
            parseSuccess = double.TryParse(readStr, out c);
        }
        if (a == 0)
        {
            double x = (-1 * c) / b;
            Console.WriteLine("\n\rWARNING: Your equations is not quadratic because a = 0.\n\r\n\rx = {0:F4}\n\r", x);
        }
        double d = (b * b) - (4 * a * c);
        if ((a != 0) && (d < 0))
        {
            Console.WriteLine("\n\rYour equations does not have roots because D < 0.\n\r\n\rD = {0:F4}\n\r", d);
        }
        if ((a != 0) && (d == 0))
        {
            double x = (-1 * b) / (2 * a);
            Console.WriteLine("\n\rYour equation has double root because D = 0.\n\r\n\rx1 = x2 = {0:F4}\n\r", x);
        }
        if ((a != 0) && (d > 0))
        {
            double x1 = ((-1 * b) + (Math.Sqrt(d))) / (2 * a);
            double x2 = ((-1 * b) - (Math.Sqrt(d))) / (2 * a);
            Console.WriteLine("\n\rYour equation has two roots because D > 0.\n\r\n\rD = {2:F4}\n\rx1 = {0:F4}\n\rx2 = {1:F4}\n\r", x1, x2, d);
        }
    }
}
