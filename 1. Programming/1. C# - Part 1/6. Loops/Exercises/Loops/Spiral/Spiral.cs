using System;

class Spiral
{
    static void Main()
    {
        Console.WindowWidth = Console.WindowWidth + 5;
        Console.WindowHeight = Console.WindowHeight + 5;
        Console.BufferHeight = Console.WindowHeight;
        string title = new string('-', 41);
        Console.Title = "Matrix";
        Console.WriteLine(title);
        Console.WriteLine("This program prints matrix in spiral form");
        Console.WriteLine(title + "\n\r");
        int number = 0;
        string readStr;
        bool parseSuccess = false;
        do
        {
            Console.Write("Enter N between 2 and 20: ");
            readStr = Console.ReadLine();
            parseSuccess = int.TryParse(readStr, out number);
        }
        while (parseSuccess == false || number < 2 || number > 20);

        int direction = 1;
        Console.WriteLine();
        // 1 - right
        // 2 - down
        // 3 - left
        // 4 - up

        int[,] matrix = new int[number, number];
        int row = 0, col = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = 0;
            }
        }

        for (int i = 1; i <= number * number; i++)
        {


            if (direction == 4) //vyrvim nagore
            {
                if (matrix[row, col] != 0)
                {
                    direction = 1;
                    i --;
                    row++;
                    col++;
                    continue;
                }
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = i;
                }
                if (row > 0)
                {
                    row--;
                }
                else
                {
                    direction = 1;
                    col++;
                }
            }

            if (direction == 3) //vyrvim nalqvo po reda
            {
                if (matrix[row, col] != 0)
                {
                    direction = 4;
                    i--;
                    row--;
                    col++;
                    continue;
                }
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = i;
                }
                if (col > 0)
                {
                    col--;
                }
                else if ((matrix[row, col] != 0) || (col <= 0))
                {
                    direction = 4;
                    row--;
                }
            }

            if (direction == 2) //vyrvim ve4e nadolu
            {
                if (matrix[row, col] != 0)
                {
                    direction = 3;
                    i--;
                    row--;
                    col--;
                    continue;
                }
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = i;
                }
                if (row < number - 1)
                {
                    row++;
                }
                else if ((matrix[row, col] != 0) || (row >= number - 1))
                {
                    direction = 3;
                    col--;
                }
            }

            if (direction == 1) //vyrvim nadqsno po reda
            {
                if (matrix[row, col] != 0)
                {
                    direction = 2;
                    i--;
                    row++;
                    col--;
                    continue;
                }
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = i;
                }
                if (col < number - 1)
                {
                    col++;
                }
                else if ((matrix[row, col] != 0) || (col >= number - 1))
                {
                    direction = 2;
                    row++;
                }
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > 0 && matrix[i, j] < 10)
                {
                    Console.Write("  " + matrix[i, j] + " ");
                }
                else if (matrix[i, j] > 9 && matrix[i, j] < 100)
                {
                    Console.Write(" " + matrix[i, j] + " ");
                }
                else
                {
                    Console.Write(matrix[i, j] + " ");
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}