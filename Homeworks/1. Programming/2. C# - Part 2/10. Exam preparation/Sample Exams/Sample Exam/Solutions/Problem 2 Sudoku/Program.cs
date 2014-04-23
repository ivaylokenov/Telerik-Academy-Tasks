using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_2_Sudoku
{
    class Program
    {
        static void Main()
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            byte[,] board = new byte[9, 9];
            for (byte i = 0; i < board.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (byte j = 0; j < board.GetLength(1); j++)
                {
                    if (line[j] == '-')
                    {
                        board[i, j] = SudokuSolver.EmptyCell;
                    }
                    else
                    {
                        board[i, j] = (byte)(line[j] - '0');
                    }
                }
            }
            SudokuSolver solver = new SudokuSolver(board);
            solver.Solve();
            board = solver.GetBoard();
            for (byte i = 0; i < board.GetLength(0); i++)
            {
                for (byte j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] == 0 ? '-' : board[i, j].ToString()[0]);
                }
                Console.WriteLine();
            }
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);
        }
    }

    class SudokuSolver
    {
        readonly byte[,] board;
        public const byte EmptyCell = 0;

        public SudokuSolver(byte[,] board)
        {
            if (board == null || board.Rank != 2)
            {
                throw new ArgumentException("Invalid board");
            }
            this.board = board;
        }

        public byte[,] GetBoard()
        {
            return board;
        }

        private bool[] GetPossibleDigits(byte i, byte j)
        {
            if (board[i, j] != EmptyCell) return new bool[9] { false, false, false, false, false, false, false, false, false };
            
            // Trying to find the only solution for the current cell
            bool[] isPossibleNumber = new bool[9] { true, true, true, true, true, true, true, true, true };
            
            // horizontal
            for (byte k = 0; k < board.GetLength(1); k++)
            {
                if (board[i, k] != EmptyCell)
                {
                    isPossibleNumber[board[i, k] - 1] = false;
                }
            }

            // vertical
            for (byte k = 0; k < board.GetLength(0); k++)
            {
                if (board[k, j] != EmptyCell)
                {
                    isPossibleNumber[board[k, j] - 1] = false;
                }
            }

            // sub-grid
            byte topLeftRow = (byte)(i - i % 3); // biggest integer that is lower than i and is divisible by 3
            byte topLeftCol = (byte)(j - j % 3); // biggest integer that is lower than j and is divisible by 3
            for (byte x = topLeftRow; x < topLeftRow + 3; x++)
            {
                for (byte y = topLeftCol; y < topLeftCol + 3; y++)
                {
                    if (board[x, y] != EmptyCell)
                    {
                        isPossibleNumber[board[x, y] - 1] = false;
                    }
                }
            }
            return isPossibleNumber;
        }

        private bool OptimizeBeforeTheRecursion()
        {
            bool optimized = false;
            for (byte i = 0; i < board.GetLength(0); i++)
            {
                for (byte j = 0; j < board.GetLength(1); j++)
                {
                    bool[] possibleDigits = GetPossibleDigits(i, j);
                    if (possibleDigits.Count(x => x) == 1)
                    {
                        for (byte k = 0; k < 9; k++)
                        {
                            if (possibleDigits[k])
                            {
                                board[i, j] = (byte)(k + 1);
                                optimized = true;
                            }
                        }
                    }
                }
            }
            return optimized;
        }

        private byte GetEmptyCellsCount()
        {
            byte count = 0;
            for (byte i = 0; i < board.GetLength(0); i++)
            {
                for (byte j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0) count++;
                }
            }
            return count;
        }

        bool solutionFound = false;

        private void SolveWithRecursion(byte i, byte j, byte empty)
        {
            if (empty == 0)
            {
                solutionFound = true;   
                return;
            }

            bool[] possibleDigits = GetPossibleDigits(i, j); // candidates for the current cell

            for (int k = 0; k < 9; k++)
            {
                if (!possibleDigits[k]) continue;
                
                board[i, j] = (byte)(k + 1);

                // Find the first empty cell:
                byte topLeftEmptyX = 0;
                byte topLeftEmptyY = 0;
                bool foundEmpty = false;
                for (byte x = i; x < board.GetLength(0); x++)
                {
                    for (byte y = 0; y < board.GetLength(1); y++)
                    {
                        if (board[x, y] == EmptyCell)
                        {
                            topLeftEmptyX = x;
                            topLeftEmptyY = y;
                            foundEmpty = true;
                            break;
                        }
                    }
                    if (foundEmpty) break;
                }

                SolveWithRecursion(topLeftEmptyX, topLeftEmptyY, (byte)(empty - 1));
                if (solutionFound) return;
            }
            board[i, j] = 0;
        }

        public void Solve()
        {
            //byte emptyBefore = GetEmptyCellsCount();
            while (OptimizeBeforeTheRecursion()) { }
            byte emptyAfter = GetEmptyCellsCount();

            byte topLeftEmptyX = 0;
            byte topLeftEmptyY = 0;
            bool foundEmpty = false;

            for (byte i = 0; i < board.GetLength(0); i++)
            {
                for (byte j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == EmptyCell)
                    {
                        topLeftEmptyX = i;
                        topLeftEmptyY = j;
                        foundEmpty = true;
                        break;
                    }
                }
                if (foundEmpty) break;
            }

            if (!foundEmpty) return; // the sudoku is already solved

            this.SolveWithRecursion(topLeftEmptyX, topLeftEmptyY, emptyAfter);
        }
    }
}
