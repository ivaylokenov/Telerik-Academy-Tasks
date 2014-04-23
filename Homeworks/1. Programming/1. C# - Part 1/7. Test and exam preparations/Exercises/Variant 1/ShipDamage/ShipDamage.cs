using System;

class ShipDamage
{
    static void Main()
    {
        int Sx1 = int.Parse(Console.ReadLine());
        int Sy1 = int.Parse(Console.ReadLine());
        int Sx2 = int.Parse(Console.ReadLine());
        int Sy2 = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        int Cx1 = int.Parse(Console.ReadLine());
        int Cy1 = int.Parse(Console.ReadLine());
        int Cx2 = int.Parse(Console.ReadLine());
        int Cy2 = int.Parse(Console.ReadLine());
        int Cx3 = int.Parse(Console.ReadLine());
        int Cy3 = int.Parse(Console.ReadLine());

        int rectangleTop = 0, rectangleBottom = 0, rectangleRight = 0, rectangleLeft = 0;
        if (Sy1 > Sy2)
        {
            rectangleTop = Sy1;
            rectangleBottom = Sy2;
        }
        if (Sy2 > Sy1)
        {
            rectangleTop = Sy2;
            rectangleBottom = Sy1;
        }
        if (Sx1 > Sx2)
        {
            rectangleRight = Sx1;
            rectangleLeft = Sx2;
        }
        if (Sx2 > Sx1)
        {
            rectangleRight = Sx2;
            rectangleLeft = Sx1;
        }


        int boom1, boom2, boom3;
        //Ship is above H
        boom1 = 2 * H - Cy1;
        boom2 = 2 * H - Cy2;
        boom3 = 2 * H - Cy3;

        int damage = 0;

        //Corners
        if ((boom1 == rectangleBottom && Cx1 == rectangleRight) || (boom1 == rectangleTop && Cx1 == rectangleRight) || (boom1 == rectangleTop && Cx1 == rectangleLeft) || (boom1 == rectangleBottom && Cx1 == rectangleLeft))
        {
            damage += 25;
        }

        if ((boom2 == rectangleBottom && Cx2 == rectangleRight) || (boom2 == rectangleTop && Cx2 == rectangleRight) || (boom2 == rectangleTop && Cx2 == rectangleLeft) || (boom2 == rectangleBottom && Cx2 == rectangleLeft))
        {
            damage += 25;
        }

        if ((boom3 == rectangleBottom && Cx3 == rectangleRight) || (boom3 == rectangleTop && Cx3 == rectangleRight) || (boom3 == rectangleTop && Cx3 == rectangleLeft) || (boom3 == rectangleBottom && Cx3 == rectangleLeft))
        {
            damage += 25;
        }

        //Sides
        if ((boom1 == rectangleBottom && Cx1 > rectangleLeft && Cx1 < rectangleRight) || (boom1 == rectangleTop && Cx1 > rectangleLeft && Cx1 < rectangleRight) || (Cx1 == rectangleLeft && boom1 > rectangleBottom && boom1 < rectangleTop) || (Cx1 == rectangleRight && boom1 > rectangleBottom && boom1 < rectangleTop))
        {
            damage += 50;
        }

        if ((boom2 == rectangleBottom && Cx2 > rectangleLeft && Cx2 < rectangleRight) || (boom2 == rectangleTop && Cx2 > rectangleLeft && Cx2 < rectangleRight) || (Cx2 == rectangleLeft && boom2 > rectangleBottom && boom2 < rectangleTop) || (Cx2 == rectangleRight && boom2 > rectangleBottom && boom2 < rectangleTop))
        {
            damage += 50;
        }

        if ((boom3 == rectangleBottom && Cx3 > rectangleLeft && Cx3 < rectangleRight) || (boom3 == rectangleTop && Cx3 > rectangleLeft && Cx3 < rectangleRight) || (Cx3 == rectangleLeft && boom3 > rectangleBottom && boom3 < rectangleTop) || (Cx3 == rectangleRight && boom3 > rectangleBottom && boom3 < rectangleTop))
        {
            damage += 50;
        }

        //inside
        if (boom1 < rectangleTop && boom1 > rectangleBottom && Cx1 > rectangleLeft && Cx1 < rectangleRight)
        {
            damage += 100;
        }

        if (boom2 < rectangleTop && boom2 > rectangleBottom && Cx2 > rectangleLeft && Cx2 < rectangleRight)
        {
            damage += 100;
        }

        if (boom3 < rectangleTop && boom3 > rectangleBottom && Cx3 > rectangleLeft && Cx3 < rectangleRight)
        {
            damage += 100;
        }

        Console.WriteLine(damage + "%");
    }
}
