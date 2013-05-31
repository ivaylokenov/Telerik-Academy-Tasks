using System;

class SequencesInMatrix
{
    //get horizontal lenght
    static int HorizontalSequence(string[,] multiArray, int currentRow, int currentCol)
    {
        int lenght = 0;
        string currentElement = multiArray[currentRow, currentCol];

        for (int col = currentCol; col < multiArray.GetLength(1); col++)
        {
            if (currentElement == multiArray[currentRow, col])
            {
                lenght++;
            }
            else
            {
                break;
            }
        }

        return lenght;
    }

    //print horizontal lenght
    static void PrintHorizontal(string[,] multiArray, int lenght, int startRow, int startCol)
    {
        for (int col = startCol; col < startCol + lenght; col++)
        {
            Console.Write(multiArray[startRow, col] + " ");
        }
        Console.WriteLine();
    }

    //get vertical lenght
    static int VerticalSequence(string[,] multiArray, int currentRow, int currentCol)
    {
        int lenght = 0;
        string currentElement = multiArray[currentRow, currentCol];

        for (int row = currentRow; row < multiArray.GetLength(0); row++)
        {
            if (currentElement == multiArray[row, currentCol])
            {
                lenght++;
            }
            else
            {
                break;
            }
        }

        return lenght;
    }

    //print vertical sequence
    static void PrintVertical(string[,] multiArray, int lenght, int startRow, int startCol)
    {
        for (int row = startRow; row < startRow + lenght; row++)
        {
            Console.Write(multiArray[row, startCol] + " ");
        }
        Console.WriteLine();
    }

    //get first diagonal lenght
    static int FirstDiagonalSequence(string[,] multiArray, int currentRow, int currentCol)
    {
        int lenght = 0;
        string currentElement = multiArray[currentRow, currentCol];

        for (int row = currentRow, col = currentCol; row < multiArray.GetLength(0) && col < multiArray.GetLength(1); row++, col++)
        {
            if (currentElement == multiArray[row, col])
            {
                lenght++;
            }
            else
            {
                break;
            }
        }

        return lenght;
    }

    //print first diagonal sequence
    static void PrintFirstDiagonal(string[,] multiArray, int lenght, int startRow, int startCol)
    {
        for (int row = startRow, col = startCol; row < startRow + lenght && col < startCol + lenght; row++, col++)
        {
            Console.Write(multiArray[row, col] + " ");
        }
        Console.WriteLine();
    }

    //check second diagonal
    static int SecondDiagonalSequence(string[,] multiArray, int currentRow, int currentCol)
    {
        int lenght = 0;
        string currentElement = multiArray[currentRow, currentCol];

        for (int row = currentRow, col = currentCol; row < multiArray.GetLength(0) && col >= 0; row++, col--)
        {
            if (currentElement == multiArray[row, col])
            {
                lenght++;
            }
            else
            {
                break;
            }
        }

        return lenght;
    }

    //print second diagonal
    static void PrintSecondDiagonal(string[,] multiArray, int lenght, int startRow, int startCol)
    {
        for (int row = startRow, col = startCol; row < startRow + lenght && col > startCol - lenght; row++, col--)
        {
            Console.Write(multiArray[row, col] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        string[,] matrix = new string[5, 6] {
            {"ha", "hi", "ha", "ho", "hu", "hu"},
            {"hi", "ha", "he", "hu", "hu", "hu"},
            {"ho", "hi", "ha", "hu", "hu", "ho"},
            {"hu", "hi", "hu", "ha", "he", "hu"},
            {"hu", "hu", "hu", "hu", "hu", "hu"},
        };
        string direction = "";
        int maxLenght = int.MinValue;
        int bestRowStart = 0;
        int bestColStart = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int currentLenght;
                //check horizontal
                currentLenght = HorizontalSequence(matrix, row, col);
                if (currentLenght > maxLenght)
                {
                    direction = "Horizontal";
                    maxLenght = currentLenght;
                    bestRowStart = row;
                    bestColStart = col;
                }

                //check vertical
                currentLenght = VerticalSequence(matrix, row, col);
                if (currentLenght > maxLenght)
                {
                    direction = "Vertical";
                    maxLenght = currentLenght;
                    bestRowStart = row;
                    bestColStart = col;
                }

                //check first diagonal
                currentLenght = FirstDiagonalSequence(matrix, row, col);
                if (currentLenght > maxLenght)
                {
                    direction = "FirstDiagonal";
                    maxLenght = currentLenght;
                    bestRowStart = row;
                    bestColStart = col;
                }

                //check second diagonal
                currentLenght = SecondDiagonalSequence(matrix, row, col);
                if (currentLenght > maxLenght)
                {
                    direction = "SecondDiagonal";
                    maxLenght = currentLenght;
                    bestRowStart = row;
                    bestColStart = col;
                }
            }
        }

        //print result
        if (direction == "Horizontal")
        {
            PrintHorizontal(matrix, maxLenght, bestRowStart, bestColStart);
        }
        if (direction == "Vertical")
        {
            PrintVertical(matrix, maxLenght, bestRowStart, bestColStart);
        }
        if (direction == "FirstDiagonal")
        {
            PrintFirstDiagonal(matrix, maxLenght, bestRowStart, bestColStart);
        }
        if (direction == "SecondDiagonal")
        {
            PrintSecondDiagonal(matrix, maxLenght, bestRowStart, bestColStart);
        }
    }
}
