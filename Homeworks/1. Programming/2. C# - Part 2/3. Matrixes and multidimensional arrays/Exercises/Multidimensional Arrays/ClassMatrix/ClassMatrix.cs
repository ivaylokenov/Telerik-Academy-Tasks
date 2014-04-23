using System;

public class Matrix
{
    public int[,] matrix;
    public int rows;
    public int cols;

    // constructor
    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
        this.rows = rows;
        this.cols = cols;
    }

    // get and set
    public int this[int rows, int cols]
    {
        get { return this.matrix[rows, cols]; }
        set { this.matrix[rows, cols] = value; }
    }

    // +
    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        // create new matrix with same rows and cols as second one
        Matrix result = new Matrix(firstMatrix.rows, firstMatrix.cols);

        // addition
        for (int i = 0; i < result.rows; i++)
        {
            for (int j = 0; j < result.cols; j++)
            {
                result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
            }
        }

        return result;
    }

    // -
    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        // create new matrix with same rows and cols as second one
        Matrix result = new Matrix(firstMatrix.rows, firstMatrix.cols);

        // substract
        for (int i = 0; i < result.rows; i++)
        {
            for (int j = 0; j < result.cols; j++)
            {
                result[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
            }
        }

        return result;
    }

    // *
    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        // create new matrix with same rows and cols as second one
        Matrix result = new Matrix(firstMatrix.rows, secondMatrix.cols);

        // multiply
        for (int i = 0; i < result.rows; i++)
        {
            for (int j = 0; j < result.cols; j++)
            {
                for (int k = 0; k < firstMatrix.cols; k++)
                {
                    result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                }
            }
        }

        return result;
    }

    // to string
    public override string ToString()
    {
        int max = this.matrix[0, 0];
        foreach (int cell in this.matrix)
        {
            max = Math.Max(cell, max);
        }

        int cellSize = Convert.ToString(max).Length;

        string result = string.Empty;

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.cols; j++)
            {
                result += (Convert.ToString(this.matrix[i, j]).PadRight(cellSize, ' ') + (j != this.cols - 1 ? " " : "\n"));
            }
        }

        return result;
    }
}

class ClassMatrix
{
    static void Main()
    {
        Matrix firstMatrix = new Matrix(4, 4);
        Matrix secondMatrix = new Matrix(4, 4);

        // enter matrix numbers by some numbers
        for (int i = 0; i < firstMatrix.rows; i++)
        {
            for (int j = 0; j < secondMatrix.rows; j++)
            {
                firstMatrix[i, j] = i + 1;
                secondMatrix[i, j] = j * 2;
            }
        }

        // print
        Console.WriteLine(firstMatrix);
        Console.WriteLine(secondMatrix);

        // add
        Console.WriteLine(firstMatrix + secondMatrix);

        // substract
        Console.WriteLine(firstMatrix - secondMatrix);

        // multiply
        Console.WriteLine(firstMatrix * secondMatrix);
    }
}
