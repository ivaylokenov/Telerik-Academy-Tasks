using System;

class PrintMatrixD
{
    // 1 - down
    // 2 - right
    // 3 - up
    // 4 - left
    static int direction = 1;
    static bool changeDirection = true;

    static void ChangeDirection()
    {
        changeDirection = true;

        if (direction == 1 && changeDirection == true)
        {
            direction = 2;
            changeDirection = false;
        }

        if (direction == 2 && changeDirection == true)
        {
            direction = 3;
            changeDirection = false;
        }

        if (direction == 3 && changeDirection == true)
        {
            direction = 4;
            changeDirection = false;
        }

        if (direction == 4 && changeDirection == true)
        {
            direction = 1;
            changeDirection = false;
        }
    }

    static void PrintMatrix(int[,] multiArray, int dimension)
    {
        string space;
        for (int row = 0; row < dimension; row++)
        {
            for (int col = 0; col < dimension; col++)
            {
                if (multiArray[row, col] < 10)
                {
                    space = "   ";
                }
                else if (multiArray[row, col] < 100)
                {
                    space = "  ";
                }
                else
                {
                    space = " ";
                }

                Console.Write(space + multiArray[row, col]);
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];

        int counter = N;
        int timesCounter = 1;
        int rows = 0;
        int cols = 0;
        int fillNumbers = 1;

        for (int number = 1; number <= N * N; number++)
        {
            matrix[rows, cols] = number;

            if (timesCounter == 1 && fillNumbers == counter)
            {
                timesCounter = 0;
                counter--;
                fillNumbers = 0;
                ChangeDirection();
            }
            else if (fillNumbers == counter)
            {
                timesCounter = 1;
                fillNumbers = 0;
                ChangeDirection();
            }

            fillNumbers++;

            if (direction == 1)
            {
                rows++;
            }

            if (direction == 2)
            {
                cols++;
            }

            if (direction == 3)
            {
                rows--;
            }

            if (direction == 4)
            {
                cols--;
            }
        }

        PrintMatrix(matrix, N);
    }
}
