using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Problem_2_Tic_Tac_Toe
{
    class Program
    {
        static void Main()
        {
            byte[,] board = new byte[3, 3];
            for (int i = 0; i < 3; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 3; j++)
                {
                    if (line[j] == '-') board[i, j] = TicTakToePrediction.EmptyCell;
                    else if (line[j] == 'X') board[i, j] = TicTakToePrediction.PlayerX;
                    else if (line[j] == 'O') board[i, j] = TicTakToePrediction.PlayerO;
                }
            }
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            TicTakToePrediction predictor = new TicTakToePrediction(board);
            predictor.Predict();
            Console.WriteLine(predictor.playerXWins);
            Console.WriteLine(predictor.evenGames);
            Console.WriteLine(predictor.playerOWins);
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed);
        }
    }

    class TicTakToePrediction
    {
        public const int EmptyCell = 0;
        public const int PlayerX = 1;
        public const int PlayerO = 2;
        public const int EvenGame = 3;
        private readonly byte[,] board;

        public TicTakToePrediction(byte[,] board)
        {
            this.board = board;
        }

        private bool Compare4Bytes(byte a, byte b, byte c, byte d)
        {
            if (a == b && b == c && c == d)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private byte GetWinner(int turn)
        {
            if (Compare4Bytes(board[0, 0], board[0, 1], board[0, 2], PlayerX)) // First row
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[1, 0], board[1, 1], board[1, 2], PlayerX)) // Second row
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[2, 0], board[2, 1], board[2, 2], PlayerX)) // Third row
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[0, 0], board[1, 0], board[2, 0], PlayerX)) // First column
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[0, 1], board[1, 1], board[2, 1], PlayerX)) // Second column
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[0, 2], board[1, 2], board[2, 2], PlayerX)) // Third column
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[0, 0], board[1, 1], board[2, 2], PlayerX)) // Diagonal 1
            {
                return PlayerX;
            }
            if (Compare4Bytes(board[0, 2], board[1, 1], board[2, 0], PlayerX)) // Diagonal 1
            {
                return PlayerX;
            }


            if (Compare4Bytes(board[0, 0], board[0, 1], board[0, 2], PlayerO)) // First row
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[1, 0], board[1, 1], board[1, 2], PlayerO)) // Second row
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[2, 0], board[2, 1], board[2, 2], PlayerO)) // Third row
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[0, 0], board[1, 0], board[2, 0], PlayerO)) // First column
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[0, 1], board[1, 1], board[2, 1], PlayerO)) // Second column
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[0, 2], board[1, 2], board[2, 2], PlayerO)) // Third column
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[0, 0], board[1, 1], board[2, 2], PlayerO)) // Diagonal 1
            {
                return PlayerO;
            }
            if (Compare4Bytes(board[0, 2], board[1, 1], board[2, 0], PlayerO)) // Diagonal 1
            {
                return PlayerO;
            }

            if (9 - turn == 0)
            {
                return EvenGame;
            }
            else
            {
                return EmptyCell;
            }

        }

        public int playerXWins = 0;
        public int playerOWins = 0;
        public int evenGames = 0;

        private void DoPredict(int turn)
        {
            byte winner = GetWinner(turn);
            if (winner != EmptyCell)
            {
                if (winner == PlayerX)
                {
                    playerXWins++;
                }
                else if (winner == PlayerO)
                {
                    playerOWins++;
                }
                else
                {
                    evenGames++;
                }
                return;
            }

            byte player;
            if (turn % 2 == 0) player = PlayerX;
            else player = PlayerO;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == EmptyCell)
                    {
                        board[i, j] = player;
                        DoPredict(turn + 1);
                        board[i, j] = EmptyCell;
                    }
                }
            }

        }

        public void Predict()
        {
            byte turn = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != EmptyCell)
                    {
                        turn++;
                    }
                }
            }
            DoPredict(turn);
        }
    }
}
