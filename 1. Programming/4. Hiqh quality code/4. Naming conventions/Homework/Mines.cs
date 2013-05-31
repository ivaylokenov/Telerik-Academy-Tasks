namespace MineSweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Mines
    {
        public static void Main(string[] arguments)
        {
            string currentCommand = string.Empty;
            char[,] field = CreatePlayField();
            char[,] mines = DeployMines();
            int counter = 0;
            bool reachedMine = false;
            List<Score> highScoreList = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool startingGame = true;
            const int MAX = 35;
            bool winGame = false;

            do
            {
                if (startingGame)
                {
                    Console.WriteLine("MineSweeper\n\r\n\rCommands:\n\rtop - shows high scores\n\rrestart - starts new game\n\rexit - exits current game");
                    Initialize(field);
                    startingGame = false;
                }

                Console.Write("Enter row and column: ");
                currentCommand = Console.ReadLine().Trim();
                if (currentCommand.Length >= 3)
                {
                    if (int.TryParse(currentCommand[0].ToString(), out row) &&
                    int.TryParse(currentCommand[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        HighScore(highScoreList);
                        break;
                    case "restart":
                        field = CreatePlayField();
                        mines = DeployMines();
                        Initialize(field);
                        reachedMine = false;
                        startingGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                NextTurn(field, mines, row, col);
                                counter++;
                            }

                            if (MAX == counter)
                            {
                                winGame = true;
                            }
                            else
                            {
                                Initialize(field);
                            }
                        }
                        else
                        {
                            reachedMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\n\rError! Invalid command!\n\r");
                        break;
                }

                if (reachedMine)
                {
                    Initialize(mines);
                    Console.Write("\nBooooom! You reached a mine and finished the hame with {0} points. Please, enter nickname: ", counter);
                    string nickName = Console.ReadLine();
                    Score currentScore = new Score(nickName, counter);
                    if (highScoreList.Count < 5)
                    {
                        highScoreList.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < highScoreList.Count; i++)
                        {
                            if (highScoreList[i].Points < currentScore.Points)
                            {
                                highScoreList.Insert(i, currentScore);
                                highScoreList.RemoveAt(highScoreList.Count - 1);
                                break;
                            }
                        }
                    }

                    highScoreList.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    highScoreList.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    HighScore(highScoreList);

                    field = CreatePlayField();
                    mines = DeployMines();
                    counter = 0;
                    reachedMine = false;
                    startingGame = true;
                }

                if (winGame)
                {
                    Console.WriteLine("\nCongratulations! You opened 35 cells without reaching a mine!");
                    Initialize(mines);
                    Console.WriteLine("Please, enter nickname: ");
                    string name = Console.ReadLine();
                    Score points = new Score(name, counter);
                    highScoreList.Add(points);
                    HighScore(highScoreList);
                    field = CreatePlayField();
                    mines = DeployMines();
                    counter = 0;
                    winGame = false;
                    startingGame = true;
                }
            }
            while (currentCommand != "exit");
            Console.WriteLine("Goodbye!");
            Console.Read();
        }

        private static void HighScore(List<Score> points)
        {
            Console.WriteLine("Points: ");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, points[i].Name, points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty highscore list!\n");
            }
        }

        private static void NextTurn(char[,] field, char[,] mines, int row, int col)
        {
            char howManyMines = HowManyMines(mines, row, col);
            mines[row, col] = howManyMines;
            field[row, col] = howManyMines;
        }

        private static void Initialize(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] DeployMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> deployedMines = new List<int>();
            while (deployedMines.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!deployedMines.Contains(number))
                {
                    deployedMines.Add(number);
                }
            }

            foreach (int mine in deployedMines)
            {
                int column = mine / cols;
                int row = mine % cols;
                if (row == 0 && mine != 0)
                {
                    column--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                playField[column, row - 1] = '*';
            }

            return playField;
        }

        private static char HowManyMines(char[,] mines, int row, int col)
        {
            int counter = 0;
            int rows = mines.GetLength(0);
            int columns = mines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mines[row - 1, col] == '*')
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (mines[row + 1, col] == '*')
                {
                    counter++;
                }
            }

            if (col - 1 >= 0)
            {
                if (mines[row, col - 1] == '*')
                {
                    counter++;
                }
            }

            if (col + 1 < columns)
            {
                if (mines[row, col + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mines[row - 1, col - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < columns))
            {
                if (mines[row - 1, col + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (mines[row + 1, col - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < columns))
            {
                if (mines[row + 1, col + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}
