using System;

class SurfaceOfATriangle
{
    static decimal SideAndAltitude(decimal side, decimal height)
    {
        decimal area = side * height / 2;
        return area;
    }

    static decimal ThreeSides(decimal firstSide, decimal secondSide, decimal thirdSide)
    {
        decimal heron = (firstSide + secondSide + thirdSide) / 2;
        decimal area = (decimal)Math.Sqrt((double)(heron * (heron - firstSide) * (heron - secondSide) * (heron - thirdSide)));
        return area;
    }

    static decimal AngleArea(decimal firstSide, decimal secondSide, decimal angle)
    {
        angle = angle * (decimal)Math.PI / 180;
        decimal area = ((decimal)Math.Sin((double)angle) * firstSide * secondSide) / 2;
        return area;
    }

    static void Main()
    {
        decimal firstSide = 5;
        decimal secondSide = 6;
        decimal thirdSide = 3;
        decimal heightToFirstSide = 4;
        decimal angle = 60;

        Console.WriteLine(SideAndAltitude(firstSide, heightToFirstSide));
        Console.WriteLine(ThreeSides(firstSide, secondSide, thirdSide));
        Console.WriteLine(AngleArea(firstSide,secondSide, angle));
    }
}
