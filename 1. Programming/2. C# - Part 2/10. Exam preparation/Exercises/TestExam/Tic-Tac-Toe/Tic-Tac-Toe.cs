using System;
using System.Collections.Generic;
using System.Text;

class Tic
{
    //BGCoder: 100/100

    static string[,] TicTac = new string[3, 3];
    static bool[,] canBeChanged = new bool[3, 3];
    static int firstWins = 0;
    static int secondWins = 0;
    static int draws = 0;
    static int currentPlayer = 1;
    static bool isFull = true;

    static void TicTacSolver(int row, int col)
    {
        //Console.SetBufferSize(80, 500);

        if (checkHorizontal(0) || checkHorizontal(1) || checkHorizontal(2) || checkVertical(0) || checkVertical(1) || checkVertical(2) || checkFirstDiagonal() || checkSecondDiagonal())
        {
            if (currentPlayer == 1)
            {
                secondWins++;
                //Console.WriteLine("Second wins!");
                return;
            }
            else if (currentPlayer == 2)
            {
                firstWins++;
                //Console.WriteLine("First wins");
                return;
            }
        }

        isFull = true;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (TicTac[i, j] == "-")
                {
                    isFull = false;
                }
            }
        }

        if (isFull)
        {
            if (checkDraw())
            {
                draws++;
                //Console.WriteLine("Draw!");
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (TicTac[i, j] == "-")
                {
                    if (currentPlayer == 1)
                    {
                        TicTac[i, j] = "X";
                        currentPlayer = 2;
                    }
                    else
                    {
                        TicTac[i, j] = "O";
                        currentPlayer = 1;
                    }

                    //PrintTicTac();

                    TicTacSolver(i, j);

                    TicTac[i, j] = "-";

                    if (currentPlayer == 1)
                    {
                        currentPlayer = 2;
                    }
                    else
                    {
                        currentPlayer = 1;
                    }
                }
            }
        }
    }

    static bool checkDraw()
    {
        bool isDraw = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (TicTac[i, j] == "-")
                {
                    isDraw = false;
                }
            }
        }

        return isDraw;
    }

    static void PrintTicTac()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(TicTac[i,j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static bool checkHorizontal(int hor)
    {
        if ((TicTac[hor, 0] == TicTac[hor, 1]) && (TicTac[hor, 2] == TicTac[hor, 1]))
        {
            if (TicTac[hor, 0] != "-" && TicTac[hor, 1] != "-" && TicTac[hor, 0] != "-")
            return true;
        }

        return false;
    }

    static bool checkVertical(int ver)
    {
        if ((TicTac[0, ver] == TicTac[1, ver]) && (TicTac[1, ver]==TicTac[2, ver]))
        {
            if (TicTac[0, ver] != "-" && TicTac[1, ver] != "-" && TicTac[2, ver] != "-")
            return true;
        }

        return false;
    }

    static bool checkFirstDiagonal()
    {
        if ((TicTac[0, 0] == TicTac[1, 1]) && (TicTac[2, 2] == TicTac[1, 1]))
        {   
            if (TicTac[0, 0] != "-" && TicTac[1, 1] != "-" && TicTac[2, 2] != "-")
            return true;
        }

        return false;
    }

    static bool checkSecondDiagonal()
    {
        if ((TicTac[0, 2] == TicTac[1, 1]) && (TicTac[2, 0] == TicTac[1, 1]))
        {
            if (TicTac[0, 2] != "-" && TicTac[1, 1] != "-" && TicTac[2, 0] != "-")
            return true;
        }

        return false;
    }

    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            string input = Console.ReadLine();

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == '-')
                {
                    TicTac[i, j] = "-";
                    canBeChanged[i, j] = true;
                }
                else
                {
                    TicTac[i, j] = input[j].ToString();
                    canBeChanged[i, j] = false;
                }
            }
        }

        int numberOfEmptyLines = 1;

        //for (int i = 0; i < 3; i++)
        //{
        //    for (int j = 0; j < 3; j++)
        //    {
        //        if (TicTac[i, j] == "-")
        //        {
        //            TicTacSolver(i, j);
        //            numberOfEmptyLines++;
        //        }
        //    }
        //}

        int Xtimes = 0;
        int Otimes = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (TicTac[i, j] == "X")
                {
                    Xtimes++;
                }
                if (TicTac[i, j] == "O")
                {
                    Otimes++;
                }
            }
        }

        if (Xtimes > Otimes)
        {
            currentPlayer = 2;
        }

        TicTacSolver(0, 0);

        Console.WriteLine(firstWins/numberOfEmptyLines);
        Console.WriteLine(draws/numberOfEmptyLines);
        Console.WriteLine(secondWins/numberOfEmptyLines);
    }
}




