using System;

public class IfStatements
{
    public static void Main()
    {
        Potato potato = new Potato();

        if (potato != null && potato.HasBeenPeeled && potato.IsHealthy)
        {
            Cook(potato);
        }

        int x = 0;
        int minimumX = 0;
        int maximumX = 0;
        int y = 0;
        int minimumY = 0;
        int maximumY = 0;
        bool shouldVisitCell = true;

        bool isValidX = minimumX <= x && x <= maximumX;
        bool isValidY = minimumY <= y && y <= maximumY;
        bool isValidCell = shouldVisitCell;

        if (isValidCell && isValidX && isValidY)
        {
            VisitCell();
        }
    }

    private static void VisitCell()
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }

    private static void Cook(Potato potato)
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
}
