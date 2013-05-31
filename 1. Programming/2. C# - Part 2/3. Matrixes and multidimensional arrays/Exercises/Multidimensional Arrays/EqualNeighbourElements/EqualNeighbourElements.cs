using System;

class EqualNeighbourElements
{
    static int currentLenght = 0;
    static int maxLenght = 0;

    static int[,] matrix = {
                           { 1, 3, 4, 4, 2, 4 }, 
                           { 3, 3, 3, 4, 4, 4 }, 
                           { 4, 3, 4, 4, 4, 3 }, 
                           { 4, 3, 1, 3, 3, 3 }, 
                           { 4, 3, 3, 3, 1, 3 },
                           };
    static bool[,] boolPath = { { true, true, true, true, true, true }, { true, true, true, true, true, true }, { true, true, true, true, true, true }, { true, true, true, true, true, true }, { true, true, true, true, true, true } };

    static void EqualNeighbours(int row, int col, int index)
    {
        // out of the matrix
        if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
        {
            return;
        }

        // if current cell is visited
        if (boolPath[row, col] == false)
        {
            return;
        }

        // mark current cell as visited
        boolPath[row, col] = false;

        // if digit is what we are looking for
        if (matrix[row, col] == index)
        {
            currentLenght++;
        }
        else
        {
            return;
        }

        // invoke recursion
        EqualNeighbours(row, col - 1, index);
        EqualNeighbours(row - 1, col, index);
        EqualNeighbours(row, col + 1, index);
        EqualNeighbours(row + 1, col, index);
    }

    static void ClearPath()
    {
        for (int i = 0; i < boolPath.GetLength(0); i++)
        {
            for (int j = 0; j < boolPath.GetLength(1); j++)
            {
                boolPath[i, j] = true;
            }
        }
    }

    static void Main()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                EqualNeighbours(i, j, matrix[i, j]);

                if (currentLenght > maxLenght)
                {
                    maxLenght = currentLenght;
                }

                ClearPath();
                currentLenght = 0;
            }
        }

        Console.WriteLine(maxLenght);
    }
}
