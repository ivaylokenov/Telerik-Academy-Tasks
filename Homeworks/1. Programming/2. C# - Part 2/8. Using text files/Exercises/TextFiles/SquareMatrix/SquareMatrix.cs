using System;
using System.IO;

class SquareMatrix
{
    static void Main()
    {
        StreamReader readFile = new StreamReader(@"..\..\..\TestFiles\Matrix.txt");
        int[,] matrix; 

        using (readFile)
        {
            string line = readFile.ReadLine();
            matrix = new int[int.Parse(line), int.Parse(line)];
            line = readFile.ReadLine();
            int row = 0;

            while (line != null)
            {
                string[] digitsOnLine = line.Split(' ');

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[row, i] = int.Parse(digitsOnLine[i]);
                }

                row++;
                line = readFile.ReadLine();
            }
        }

        //Print matrix
        //for (int i = 0; i < matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j < matrix.GetLength(1); j++)
        //    {
        //        Console.Write(matrix[i,j] + " ");
        //    }
        //    Console.WriteLine();
        //}

        int maxSum = int.MinValue;

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                int sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }
        }

        StreamWriter writeFile = new StreamWriter(@"..\..\..\TestFiles\ResultFromMatrix.txt");

        using (writeFile)
        {
            writeFile.Write(maxSum);
        }

        Console.WriteLine(@"Result was saved to TestFiles\ResultFromMatrix.txt");
    }
}
