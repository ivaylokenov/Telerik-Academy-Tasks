using System;

class PrintMatrixC
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];

        int nextDiagonalRow = N - 1;
        int nextDiagonalCol = 0;
        int rows = nextDiagonalRow;
        int cols = 0;

        for (int number = 1; number <= N * N; number++)
        {
            matrix[rows, cols] = number;
            rows++;
            cols++;
            if (rows > N - 1 && nextDiagonalRow > 0)
            {
                nextDiagonalRow--;
                rows = nextDiagonalRow;
                cols = nextDiagonalCol;
            }
            if (cols > N - 1)
            {
                nextDiagonalCol++;
                rows = nextDiagonalRow;
                cols = nextDiagonalCol;
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
