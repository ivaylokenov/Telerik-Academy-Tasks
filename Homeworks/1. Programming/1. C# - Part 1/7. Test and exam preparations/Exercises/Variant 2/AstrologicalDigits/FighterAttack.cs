using System;

class FighterAttack
{
    static void Main()
    {
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int boomCentralX = fx + d;
        int boomCentralY = fy;
        int boomFrontX = boomCentralX + 1;
        int boomFrontY = fy;
        int boomLeftX = boomCentralX;
        int boomLeftY = boomCentralY + 1;
        int boomRightX = boomCentralX;
        int boomRightY = boomCentralY - 1;
        int rectangleLeft = 0;
        int rectangleRight = 0;
        int rectangleTop = 0;
        int rectangleBottom = 0;
        int damage = 0;
        if (px1 > px2)
        {
            rectangleRight = px1;
            rectangleLeft = px2;
        }
        else
        {
            rectangleRight = px2;
            rectangleLeft = px1;
        }
        if (py1 > py2)
        {
            rectangleTop = py1;
            rectangleBottom = py2;
        }
        else
        {
            rectangleTop = py2;
            rectangleBottom = py1;
        }
        if (boomCentralX <= rectangleRight && boomCentralX >= rectangleLeft && boomCentralY <= rectangleTop && boomCentralY >= rectangleBottom)
        {
            damage += 100;
        }
        if (boomFrontX <= rectangleRight && boomFrontX >= rectangleLeft && boomFrontY <= rectangleTop && boomFrontY >= rectangleBottom)
        {
            damage += 75;
        }
        if (boomRightX <= rectangleRight && boomRightX >= rectangleLeft && boomRightY <= rectangleTop && boomRightY >= rectangleBottom)
        {
            damage += 50;
        }
        if (boomLeftX <= rectangleRight && boomLeftX >= rectangleLeft && boomLeftY <= rectangleTop && boomLeftY >= rectangleBottom)
        {
            damage += 50;
        }
        Console.WriteLine("{0}%", damage);
    }
}
