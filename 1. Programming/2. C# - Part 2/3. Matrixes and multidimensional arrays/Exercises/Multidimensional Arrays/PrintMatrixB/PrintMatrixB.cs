using System;

class PrintMatrixB
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];

        int direction = 0;
        int rows = 0;
        int cols = 0;
        bool nextNumber = false;
        for (int number = 1; number <= N * N; number++)
        {
            nextNumber = true;
            if (direction == 0 && nextNumber == true)
            {
                if (rows < N - 1)
                {
                    matrix[rows, cols] = number;
                    rows++;
                }
                else
                {
                    matrix[rows, cols] = number;
                    direction = 1;
                    rows = N - 1;
                    if (cols < N)
                    {
                        cols++;
                    }
                    nextNumber = false;
                }
            }

            if (direction == 1 && nextNumber == true)
            {
                if (rows > 0)
                {
                    matrix[rows, cols] = number;
                    rows--;
                }
                else
                {
                    matrix[rows, cols] = number;
                    direction = 0;
                    rows = 0;
                    if (cols < N)
                    {
                        cols++;
                    }
                    nextNumber = false;
                }
            }
        }

        string space;
        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (matrix[row, col] < 10)
                {
                    space = "  ";
                }
                else
                {
                    space = " ";
                }
                Console.Write(space + matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
