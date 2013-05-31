using System;

class Pillars
{
    static void Main()
    {
        int[,] grid = new int[8, 8];
        int number;
        string readStr;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            readStr = Console.ReadLine();
            number = int.Parse(readStr);
            for (int j = grid.GetLength(1) - 1; j >= 0; j--)
            {
                grid[i, j] = number % 2;
                number /= 2;
            }
        }

        int leftFullCells = 0, rightFullCells = 0, pillarNumber = 20, currentCells = 0;
        for (int i = 0; i <= 7; i++) //pillars
        {
            leftFullCells = 0;
            rightFullCells = 0;
            //left side
            for (int j = 0; j <= 7; j++)//redove
            {
                for (int k = i + 1; k <= 7; k++)//koloni
                {
                    if (grid[j, k] == 1)
                    {
                        leftFullCells++;
                    }
                }
            }

            //right side
            for (int j = 0; j <= 7; j++)
            {
                for (int k = 0; k <= i - 1; k++)
                {
                    if (grid[j, k] == 1)
                    {
                        rightFullCells++;
                    }
                }
            }


            if (leftFullCells == rightFullCells & i < pillarNumber)
            {
                pillarNumber = i;
                currentCells = rightFullCells;
            }
        }

        if (pillarNumber < 20)
        {
            Console.WriteLine(7 - pillarNumber);
            Console.WriteLine(currentCells);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}