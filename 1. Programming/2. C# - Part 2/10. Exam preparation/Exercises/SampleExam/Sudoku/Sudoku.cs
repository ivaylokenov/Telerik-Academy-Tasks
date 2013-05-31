using System;
using System.Text;
using System.Threading;

class SudokuSolve
{
    //BGCoder: 100/100

    static int[,] Sudoku = new int[9, 9];
    static bool[,] canBeChanged = new bool[9, 9];

    static void PrintSudoku()
    {
        //Console.SetCursorPosition(0, 0);
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (Sudoku[i, j] == 0)
                {
                    Console.Write('-');
                }
                else
                {
                    Console.Write(Sudoku[i,j]);
                }
            }
            Console.WriteLine();
        }
    }
    /*
53--7----
6--195---
-98----6-
8---6---3
4--8-3--1
7---2---6
-6----28-
---419--5
----8--79
     */ 

    static void SudokuSolver(int row, int col)
    {
        //Thread.Sleep(20);
        //PrintSudoku();
        if (row == 8 && col == 8)
        {
            if (Sudoku[row, col] != 0)
            {
                throw new Exception();
            }
            else
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (CheckRow(row, i))
                    {
                        continue;
                    }
                    if (CheckColumn(col, i))
                    {
                        continue;
                    }
                    if (CheckSubSquare(row, col, i))
                    {
                        continue;
                    }

                    Sudoku[row, col] = i;

                    throw new Exception();
                }
            }
        }

        if (Sudoku[row, col] == 0)
        {
            for (int i = 1; i <= 9; i++)
            {
                if (CheckRow(row, i))
                {
                    continue;
                }
                if (CheckColumn(col, i))
                {
                    continue;
                }
                if (CheckSubSquare(row, col, i))
                {
                    continue;
                }

                Sudoku[row, col] = i;

                SudokuSolver(NextRow(row, col), NextCol(row, col));
            }
        }
        else
        {
            SudokuSolver(NextRow(row, col), NextCol(row, col));
        }

        if (canBeChanged[row, col])
        {
            Sudoku[row, col] = 0;
        }
    }
    
    static int NextRow(int row, int col)
    {
        col++;
        if (col > 8)
        {
            row++;
        }

        return row;
    }

    static int NextCol(int row, int col)
    {
        col++;
        if (col > 8)
        {
            col = 0;
        }

        return col;
    }

    static bool CheckRow(int row, int number)
    {
        bool hasNumberInRow = false;

        for (int i = 0; i < 9; i++)
        {
            if (Sudoku[row, i] == number)
            {
                hasNumberInRow = true;
                break;
            }
        }

        return hasNumberInRow;
    }

    static bool CheckColumn(int column, int number)
    {
        bool hasNumberInColumn = false;

        for (int i = 0; i < 9; i++)
        {
            if (Sudoku[i, column] == number)
            {
                hasNumberInColumn = true;
                break;
            }
        }

        return hasNumberInColumn;
    }

    static bool CheckSubSquare(int row, int col, int number)
    {
        bool hasNumberInSquare = false;
        int startRow = 0;
        int startCol = 0;

        if (row < 3)
        {
            if (col < 3)
            {
                startRow = 0;
                startCol = 0;
            }
            else if (col < 6)
            {
                startRow = 0;
                startCol = 3;
            }
            else
            {
                startRow = 0;
                startCol = 6;
            }
        }
        else if (row < 6)
        {
            if (col < 3)
            {
                startRow = 3;
                startCol = 0;
            }
            else if (col < 6)
            {
                startRow = 3;
                startCol = 3;
            }
            else
            {
                startRow = 3;
                startCol = 6;
            }
        }
        else
        {
            if (col < 3)
            {
                startRow = 6;
                startCol = 0;
            }
            else if (col < 6)
            {
                startRow = 6;
                startCol = 3;
            }
            else
            {
                startRow = 6;
                startCol = 6;
            }
        }


        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (Sudoku[i, j] == number)
                {
                    hasNumberInSquare = true;
                    return hasNumberInSquare;
                }
            }
        }

        return hasNumberInSquare;
    }

    static void Main()
    {
        for (int i = 0; i < 9; i++)
        {
            string input = Console.ReadLine();

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == '-')
                {
                    Sudoku[i, j] = 0;
                    canBeChanged[i,j] = true;
                    continue;
                }
                else
                {
                    Sudoku[i, j] = int.Parse(input[j].ToString());
                    canBeChanged[i, j] = false;
                }
            }
        }

        try
        {
            SudokuSolver(0, 0);
        }
        catch (Exception)
        {
            PrintSudoku();
        }
    }
}
