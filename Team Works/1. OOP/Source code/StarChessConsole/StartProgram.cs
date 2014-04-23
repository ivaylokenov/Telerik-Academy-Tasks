using System;

namespace StarChessConsole
{
    class StartProgram
    {
        public static FigurePositions BoardFigures = new FigurePositions();

        //players
        public static Player WhitePlayer;
        public static Player BlackPlayer;

        //history
        public static History WhiteHistory = new History();
        public static History BlackHistory = new History();

        //timers
        static Timer whiteTimer = new Timer(5);
        static Timer blackTimer = new Timer(5);

        public static string CurrentPlayer = "white";
        public static Colors CurrentColor = Colors.White;

        static void InitialBoard()
        {
            FigureProperties[,] initialPosition = new FigureProperties[8, 8];

            initialPosition[0, 0] = new FigureProperties(Names.Rook, Colors.Black);
            initialPosition[0, 1] = new FigureProperties(Names.Knight, Colors.Black);
            initialPosition[0, 2] = new FigureProperties(Names.Bishop, Colors.Black);
            initialPosition[0, 3] = new FigureProperties(Names.Queen, Colors.Black);
            initialPosition[0, 4] = new FigureProperties(Names.King, Colors.Black);
            initialPosition[0, 5] = new FigureProperties(Names.Bishop, Colors.Black);
            initialPosition[0, 6] = new FigureProperties(Names.Knight, Colors.Black);
            initialPosition[0, 7] = new FigureProperties(Names.Rook, Colors.Black);

            for (int i = 0; i < 8; i++)
            {
                initialPosition[1, i] = new FigureProperties(Names.Pawn, Colors.Black);
            }

            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    initialPosition[i, j] = new FigureProperties(Names.None, Colors.None);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                initialPosition[6, i] = new FigureProperties(Names.Pawn, Colors.White);
            }

            initialPosition[7, 0] = new FigureProperties(Names.Rook, Colors.White);
            initialPosition[7, 1] = new FigureProperties(Names.Knight, Colors.White);
            initialPosition[7, 2] = new FigureProperties(Names.Bishop, Colors.White);
            initialPosition[7, 3] = new FigureProperties(Names.Queen, Colors.White);
            initialPosition[7, 4] = new FigureProperties(Names.King, Colors.White);
            initialPosition[7, 5] = new FigureProperties(Names.Bishop, Colors.White);
            initialPosition[7, 6] = new FigureProperties(Names.Knight, Colors.White);
            initialPosition[7, 7] = new FigureProperties(Names.Rook, Colors.White);

            BoardFigures.Position = initialPosition;
        }

        static void PlayerInitialisation()
        {
            //player initialisation
            Console.Clear();
            System.Console.SetCursorPosition(42, 18);
            System.Console.WriteLine("JUST STAR CHESS\n\r");

            System.Console.SetCursorPosition(38, 20);
            Console.Write("Enter Player 1 Name: ");
            string name = Console.ReadLine();
            WhitePlayer = new Player(name, Colors.White);

            Console.Clear();
            System.Console.SetCursorPosition(42, 18);
            System.Console.WriteLine("JUST STAR CHESS\n\r");
            System.Console.SetCursorPosition(38, 20);
            Console.Write("Enter Player 2 Name: ");
            name = Console.ReadLine();
            while (name == WhitePlayer.Name)
            {
                System.Console.SetCursorPosition(38, 20);
                Console.Write("Enter Player 2 Name: Name already taken!");
                System.Threading.Thread.Sleep(1000);
                System.Console.SetCursorPosition(38, 20);
                Console.Write("Enter Player 2 Name:                    ");
                System.Console.SetCursorPosition(59, 20);
                name = Console.ReadLine();
            }

            BlackPlayer = new Player(name, Colors.Black);
        }

        static void ShowHistory()
        {
            //History
            Console.SetCursorPosition(89, 3);
            Console.WriteLine("HISTORY");

            Console.SetCursorPosition(86, 5);
            Console.WriteLine("WHITE   BLACK");

            int counter = 7;

            for (int i = 0; i < WhiteHistory.Count; i++)
            {
                Console.SetCursorPosition(86, counter);
                Console.Write(WhiteHistory[i]);
                counter++;
            }

            counter = 7;

            for (int i = 0; i < BlackHistory.Count; i++)
            {
                Console.SetCursorPosition(94, counter);
                Console.Write(BlackHistory[i]);
                counter++;
            }
        }

        static void ShowTakenFigures()
        {
            //TakenFigures
            Console.SetCursorPosition(86, 20);
            Console.WriteLine("TAKEN FIGURES");

            Console.SetCursorPosition(86, 22);
            Console.WriteLine("WHITE   BLACK");

            int counter = 24;

            for (int i = 0; i < WhitePlayer.TakenFigures.Count; i++)
            {
                Console.SetCursorPosition(86, counter);
                Console.Write(WhitePlayer.TakenFigures[i]);
                counter++;
            }

            counter = 24;

            for (int i = 0; i < BlackPlayer.TakenFigures.Count; i++)
            {
                Console.SetCursorPosition(94, counter);
                Console.Write(BlackPlayer.TakenFigures[i]);
                counter++;
            }
        }

        static void Main()
        {
            //console settings
            Console.Title = "Just Star Chess";
            Console.BufferHeight = 50;
            Console.BufferWidth = 102;
            Console.SetWindowSize(102, 50);

            string menu = Menu.Initialise();
            bool hasLoaded = false;

            Board board = new Board();

            InitialBoard();

            WhitePlayer = new Player("None", Colors.White);
            BlackPlayer = new Player("None", Colors.Black);

            switch (menu)
            {
                case "LOAD":
                    try
                    {
                        Menu.Load();
                        hasLoaded = true;
                    }
                    catch (Exception)
                    {
                        System.Console.SetCursorPosition(33, 27);
                        System.Console.Write("No file to load! Starting a new game...");
                        System.Threading.Thread.Sleep(2500);
                        hasLoaded = false;
                    }
                    break;
                case "HELP":
                    Menu.Help();
                    break;
                case "EXIT":
                    Console.SetCursorPosition(0, 0);
                    return;
            }

            bool hasCheck = false;

            //check for loading
            if (!hasLoaded)
            {
                PlayerInitialisation();
            }

            while (true)
            {
                whiteTimer.StartCounting = DateTime.Now;
                blackTimer.StartCounting = DateTime.Now;

                Console.SetCursorPosition(37, 2);

                Console.BackgroundColor = ConsoleColor.Black;

                board.PrintBoard(BoardFigures);

                Console.BackgroundColor = ConsoleColor.Black;

                //hasCheck = ChessChecker.ChessValidator(BoardFigures); (for check checking but it is buggy)

                //if check
                if (hasCheck)
                {
                    Console.SetCursorPosition(29, 2);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("CHECK!");
                }
                else
                {
                    Console.SetCursorPosition(29, 2);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("      ");
                }

                ShowHistory();

                ShowTakenFigures();

                Console.SetCursorPosition(36, 2);

                Console.Write("                                                  "); //clears old symbols on console

                Console.SetCursorPosition(36, 2);

                if (CurrentPlayer == "white")
                {
                    Console.Write("{0}{1}: ", WhitePlayer.Name[0].ToString().ToUpper(), WhitePlayer.Name.Substring(1));
                }
                else
                {
                    Console.Write("{0}{1}: ", BlackPlayer.Name[0].ToString().ToUpper(), BlackPlayer.Name.Substring(1));
                }

                string input = Console.ReadLine();

                if (input.ToUpper() == "EXIT")
                {
                    Console.SetCursorPosition(0, 0);
                    return;
                }
                else if (input.ToUpper() == "LOAD")
                {
                    try
                    {
                        Menu.Load();
                        Console.SetCursorPosition(34, 2);
                        Console.Write("   Game loaded");
                        System.Threading.Thread.Sleep(1000);
                        Console.SetCursorPosition(31, 2);
                        Console.Write("                         ");
                        continue;
                    }
                    catch (Exception)
                    {
                        System.Console.SetCursorPosition(35, 2);
                        System.Console.Write("No file to load!");
                        System.Threading.Thread.Sleep(1000);
                        Console.SetCursorPosition(25, 2);
                        Console.Write("                                        ");
                        continue;
                    }
                }
                else if (input.ToUpper() == "SAVE")
                {
                    Menu.Save();
                    Console.SetCursorPosition(34, 2);
                    Console.Write("   Game saved");
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(31, 2);
                    Console.Write("                         ");
                    continue;
                }

                Input currentInput = new Input(input);

                try
                {
                    currentInput.ValidateInput();
                }
                catch
                {
                    Console.SetCursorPosition(31, 2);
                    Console.Write("   Invalid command!");
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(31, 2);
                    Console.Write("                          ");
                    continue;
                }

                {
                    string forHistory = input;

                    input = currentInput.GetFieldCoordinates();

                    string[] coordinateSplit = input.Split('-');

                    int lastRow = int.Parse(coordinateSplit[0]);
                    int lastCol = int.Parse(coordinateSplit[1]);

                    //for check and mate
                    int nextCol = int.Parse(coordinateSplit[2]);
                    int nextRow = int.Parse(coordinateSplit[3]);

                    FigureProperties figure = BoardFigures.Position[lastCol, lastRow];

                    //check player color
                    if (figure.Name != Names.None && figure.Color != CurrentColor)
                    {
                        Console.SetCursorPosition(31, 2);
                        Console.Write("Figure is not your color!");
                        System.Threading.Thread.Sleep(1000);
                        Console.SetCursorPosition(31, 2);
                        Console.Write("                         ");
                        continue;
                    }

                    //create figures
                    Pawn pawn = new Pawn(figure.Color, figure.Name);
                    Knight knight = new Knight(figure.Color, figure.Name);
                    Bishop bishop = new Bishop(figure.Color, figure.Name);
                    Rook rook = new Rook(figure.Color, figure.Name);
                    Queen queen = new Queen(figure.Color, figure.Name);
                    King king = new King(figure.Color, figure.Name);

                    if (figure.Name == Names.None)
                    {
                        Console.SetCursorPosition(31, 2);
                        Console.Write("     Empty field!");
                        System.Threading.Thread.Sleep(1000);
                        Console.SetCursorPosition(31, 2);
                        Console.Write("                         ");
                        continue;
                    }
                    else if (figure.Name == Names.Pawn)
                    {
                        if (!pawn.MoveFigure(input, BoardFigures))
                        {
                            Console.SetCursorPosition(31, 2);
                            Console.Write("Pawn cannot move this way!");
                            System.Threading.Thread.Sleep(1000);
                            Console.SetCursorPosition(31, 2);
                            Console.Write("                          ");
                            continue;
                        }
                        else
                        {
                            if (CurrentPlayer == "white")
                            {
                                hasCheck = pawn.MakesChess(nextRow, nextCol, WhitePlayer, BoardFigures);
                            }
                            else
                            {
                                hasCheck = pawn.MakesChess(nextRow, nextCol, BlackPlayer, BoardFigures);
                            }
                        }
                    }
                    else if (figure.Name == Names.Knight)
                    {
                        if (!knight.MoveFigure(input, BoardFigures))
                        {
                            Console.SetCursorPosition(31, 2);
                            Console.Write("Knight cannot move this way!");
                            System.Threading.Thread.Sleep(1000);
                            Console.SetCursorPosition(31, 2);
                            Console.Write("                          ");
                            continue;
                        }
                        else
                        {
                            if (CurrentPlayer == "white")
                            {
                                hasCheck = knight.MakesChess(nextRow, nextCol, WhitePlayer, BoardFigures);
                            }
                            else
                            {
                                hasCheck = knight.MakesChess(nextRow, nextCol, BlackPlayer, BoardFigures);
                            }
                        }
                    }
                    else if (figure.Name == Names.Bishop)
                    {
                        if (!bishop.MoveFigure(input, BoardFigures))
                        {
                            Console.SetCursorPosition(31, 2);
                            Console.Write("Bishop cannot move this way!");
                            System.Threading.Thread.Sleep(1000);
                            Console.SetCursorPosition(31, 2);
                            Console.Write("                          ");
                            continue;
                        }
                        else
                        {
                            if (CurrentPlayer == "white")
                            {
                                hasCheck = bishop.MakesChess(nextRow, nextCol, WhitePlayer, BoardFigures);
                            }
                            else
                            {
                                hasCheck = bishop.MakesChess(nextRow, nextCol, BlackPlayer, BoardFigures);
                            }
                        }
                    }
                    else if (figure.Name == Names.Rook)
                    {
                        if (!rook.MoveFigure(input, BoardFigures))
                        {
                            Console.SetCursorPosition(31, 2);
                            Console.Write("Rook cannot move this way!");
                            System.Threading.Thread.Sleep(1000);
                            Console.SetCursorPosition(31, 2);
                            Console.Write("                          ");
                            continue;
                        }
                        else
                        {
                            if (CurrentPlayer == "white")
                            {
                                hasCheck = rook.MakesChess(nextRow, nextCol, WhitePlayer, BoardFigures);
                            }
                            else
                            {
                                hasCheck = rook.MakesChess(nextRow, nextCol, BlackPlayer, BoardFigures);
                            }
                        }
                    }
                    else if (figure.Name == Names.Queen)
                    {
                        if (!queen.MoveFigure(input, BoardFigures))
                        {
                            Console.SetCursorPosition(31, 2);
                            Console.Write("Queen cannot move this way!");
                            System.Threading.Thread.Sleep(1000);
                            Console.SetCursorPosition(31, 2);
                            Console.Write("                          ");
                            continue;
                        }
                        else
                        {
                            if (CurrentPlayer == "white")
                            {
                                hasCheck = queen.MakesChess(nextRow, nextCol, WhitePlayer, BoardFigures);
                            }
                            else
                            {
                                hasCheck = queen.MakesChess(nextRow, nextCol, BlackPlayer, BoardFigures);
                            }
                        }
                    }
                    else if (figure.Name == Names.King)
                    {
                        if (!king.MoveFigure(input, BoardFigures))
                        {
                            Console.SetCursorPosition(31, 2);
                            Console.Write("King cannot move this way!");
                            System.Threading.Thread.Sleep(1000);
                            Console.SetCursorPosition(31, 2);
                            Console.Write("                          ");
                            continue;
                        }
                        else
                        {
                            if (CurrentPlayer == "white")
                            {
                                hasCheck = king.MakesChess(nextRow, nextCol, WhitePlayer, BoardFigures);
                            }
                            else
                            {
                                hasCheck = king.MakesChess(nextRow, nextCol, BlackPlayer, BoardFigures);
                            }
                        }
                    }

                    //add move into history
                    if (CurrentPlayer == "white")
                    {
                        WhiteHistory.Manage(forHistory.ToUpper());
                    }
                    else
                    {
                        BlackHistory.Manage(forHistory.ToUpper());
                    }

                    //change players
                    if (CurrentPlayer == "white")
                    {
                        CurrentPlayer = "black";
                        CurrentColor = Colors.Black;
                    }
                    else
                    {
                        CurrentPlayer = "white";
                        CurrentColor = Colors.White;
                    }
                }
            }
        }
    }
}
