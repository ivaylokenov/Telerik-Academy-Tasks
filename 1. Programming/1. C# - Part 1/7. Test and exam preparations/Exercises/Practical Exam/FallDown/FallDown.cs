using System;

class FallDown
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

        for (int k = 0; k < 8; k++)
        {
            for (int i = grid.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1 && grid[i + 1, j] == 0)
                    {
                        grid[i, j] = 0;
                        grid[i + 1, j] = 1;
                    }
                }
            }
        }
        string result = "";
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                result += grid[i, j];
            }
            result = Convert.ToInt32(result, 2).ToString();
            Console.WriteLine(result);
            result = "";
        }
    }
}
