namespace StarChessConsole
{
    static class Menu
    {
        public static string Initialise()
        {
            System.Console.SetCursorPosition(43, 18);

            System.Console.WriteLine("JUST STAR CHESS\n\r");

            System.Console.SetCursorPosition(48, 20);
            System.Console.WriteLine("Menu:");

            System.Console.SetCursorPosition(41, 22);
            System.Console.WriteLine("START - New game");
            System.Console.SetCursorPosition(41, 23);
            System.Console.WriteLine("LOAD  - Load game");
            System.Console.SetCursorPosition(41, 24);
            System.Console.WriteLine("HELP  - Game commands");
            System.Console.SetCursorPosition(41, 25);
            System.Console.WriteLine("EXIT  - Quit game");
            System.Console.SetCursorPosition(43, 27);
            System.Console.Write("Command: ");
            string menuInput = System.Console.ReadLine().ToUpper();

            while (menuInput != "START" && menuInput != "LOAD" && menuInput != "HELP" && menuInput != "EXIT")
            {
                System.Console.SetCursorPosition(43, 27);
                System.Console.Write("Command: Invalid command!");
                System.Threading.Thread.Sleep(1000);
                System.Console.SetCursorPosition(43, 27);
                System.Console.Write("Command:                 ");
                System.Console.SetCursorPosition(52, 27);
                menuInput = System.Console.ReadLine().ToUpper();
            }

            return menuInput;
        }

        public static void Save()
        {
            System.IO.StreamWriter saving = new System.IO.StreamWriter("savedgame.chess");

            using (saving)
            {
                saving.WriteLine(StartProgram.CurrentPlayer);
                saving.WriteLine(StartProgram.WhitePlayer.Name);
                saving.WriteLine(StartProgram.BlackPlayer.Name);

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        saving.WriteLine(StartProgram.BoardFigures.Position[i, j].Name);
                        saving.WriteLine(StartProgram.BoardFigures.Position[i, j].Color);
                    }
                }

                saving.WriteLine(StartProgram.WhiteHistory.Count);

                for (int i = 0; i < StartProgram.WhiteHistory.Count; i++)
                {
                    saving.WriteLine(StartProgram.WhiteHistory[i]);
                }

                saving.WriteLine(StartProgram.BlackHistory.Count);

                for (int i = 0; i < StartProgram.BlackHistory.Count; i++)
                {
                    saving.WriteLine(StartProgram.BlackHistory[i]);
                }

                saving.WriteLine(StartProgram.WhitePlayer.TakenFigures.Count);

                for (int i = 0; i < StartProgram.WhitePlayer.TakenFigures.Count; i++)
                {
                    saving.WriteLine(StartProgram.WhitePlayer.TakenFigures[i]);
                }

                saving.WriteLine(StartProgram.BlackPlayer.TakenFigures.Count);

                for (int i = 0; i < StartProgram.BlackPlayer.TakenFigures.Count; i++)
                {
                    saving.WriteLine(StartProgram.BlackPlayer.TakenFigures[i]);
                }
            }
        }

        public static void Load()
        {
            System.IO.StreamReader loading = new System.IO.StreamReader("savedgame.chess");

            using (loading)
            {
                StartProgram.CurrentPlayer = loading.ReadLine();
                if (StartProgram.CurrentPlayer == "white")
                {
                    StartProgram.CurrentColor = Colors.White;
                }
                else
                {
                    StartProgram.CurrentColor = Colors.Black;
                }
                StartProgram.WhitePlayer.Name = loading.ReadLine();
                StartProgram.BlackPlayer.Name = loading.ReadLine();

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        string name = loading.ReadLine();
                        switch (name)
                        {
                            case "Rook": StartProgram.BoardFigures.Position[i, j].Name = Names.Rook; break;
                            case "Bishop": StartProgram.BoardFigures.Position[i, j].Name = Names.Bishop; break;
                            case "Knight": StartProgram.BoardFigures.Position[i, j].Name = Names.Knight; break;
                            case "Pawn": StartProgram.BoardFigures.Position[i, j].Name = Names.Pawn; break;
                            case "King": StartProgram.BoardFigures.Position[i, j].Name = Names.King; break;
                            case "Queen": StartProgram.BoardFigures.Position[i, j].Name = Names.Queen; break;
                            case "None": StartProgram.BoardFigures.Position[i, j].Name = Names.None; break;
                        }
                        string color = loading.ReadLine();
                        switch (color)
                        {
                            case "Black": StartProgram.BoardFigures.Position[i, j].Color = Colors.Black; break;
                            case "White": StartProgram.BoardFigures.Position[i, j].Color = Colors.White; break;
                            case "None": StartProgram.BoardFigures.Position[i, j].Color = Colors.None; break;
                        }
                    }
                }

                StartProgram.WhiteHistory.Clear();
                int count = int.Parse(loading.ReadLine());
                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        StartProgram.WhiteHistory.Manage(loading.ReadLine());
                    }
                }

                StartProgram.BlackHistory.Clear();
                count = int.Parse(loading.ReadLine());
                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        StartProgram.BlackHistory.Manage(loading.ReadLine());
                    }
                }

                StartProgram.WhitePlayer.TakenFigures.Clear();
                count = int.Parse(loading.ReadLine());
                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string name = loading.ReadLine();
                        switch (name)
                        {
                            case "Rook": StartProgram.WhitePlayer.AddTakenFigure(Names.Rook); break;
                            case "Bishop": StartProgram.WhitePlayer.AddTakenFigure(Names.Bishop); break;
                            case "Knight": StartProgram.WhitePlayer.AddTakenFigure(Names.Knight); break;
                            case "Pawn": StartProgram.WhitePlayer.AddTakenFigure(Names.Pawn); break;
                            case "King": StartProgram.WhitePlayer.AddTakenFigure(Names.King); break;
                            case "Queen": StartProgram.WhitePlayer.AddTakenFigure(Names.Queen); break;
                        }
                    }
                }

                StartProgram.BlackPlayer.TakenFigures.Clear();
                count = int.Parse(loading.ReadLine());
                if (count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        string name = loading.ReadLine();
                        switch (name)
                        {
                            case "Rook": StartProgram.BlackPlayer.AddTakenFigure(Names.Rook); break;
                            case "Bishop": StartProgram.BlackPlayer.AddTakenFigure(Names.Bishop); break;
                            case "Knight": StartProgram.BlackPlayer.AddTakenFigure(Names.Knight); break;
                            case "Pawn": StartProgram.BlackPlayer.AddTakenFigure(Names.Pawn); break;
                            case "King": StartProgram.BlackPlayer.AddTakenFigure(Names.King); break;
                            case "Queen": StartProgram.BlackPlayer.AddTakenFigure(Names.Queen); break;
                        }
                    }
                }
            }

        }

        public static void Help()
        {
            throw new System.NotImplementedException();
        }
    }
}
