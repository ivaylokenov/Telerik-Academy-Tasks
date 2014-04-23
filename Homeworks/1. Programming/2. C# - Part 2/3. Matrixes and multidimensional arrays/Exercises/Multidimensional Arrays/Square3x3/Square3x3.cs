using System;

class Square3x3
{
    //read matrix
    static void ReadMatrix(int[,] multiArray, int rows, int cols)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("Enter element [{0}][{1}]: ", row, col);
                multiArray[row, col] = int.Parse(Console.ReadLine());
            }
        }
    }

    //sum of 3x3 square
    static int Sum3x3(int[,] multiArray, int rows, int cols)
    {
        int sum = 0;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                sum += multiArray[rows + row, col + cols];
            }
        }
        return sum;
    }

    //print the square
    static void PrintSquare(int[,] multiArray, int startRow, int startCol)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                Console.Write(multiArray[startRow + row, startCol + col] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        //dimensions of matrix
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter M: ");
        int M = int.Parse(Console.ReadLine());
        int[,] matrix = new int[N, M];

        //read matrix
        ReadMatrix(matrix, N, M);

        int maxSum = int.MinValue;
        int bestCol = 0;
        int bestRow = 0;

        //find square
        for (int row = 0; row < N - 2; row++)
        {
            for (int col = 0; col < M - 2; col++)
            {
                int currentSum = Sum3x3(matrix, row, col);
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    bestCol = col;
                    bestRow = row;
                }
            }
        }

        //print result
        Console.WriteLine("The 3x3 square with maximum sum is:");
        PrintSquare(matrix, bestRow, bestCol);
        Console.WriteLine("Maximum sum is: {0}.", maxSum);
    }
}
