using System;

class PrintMatrixA
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, N];

        for (int row = 0; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                int number = row + col * N + 1;
                matrix[row, col] = number;
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