namespace StarChessConsole
{
    class Field
    {
        //this is a Black, can be empty, or can contain figure

        public void PrintField(int cursorX, int cursorY, FigureProperties currentFigure, System.ConsoleColor color)
        {
            for (int row = 1; row < 6; row++)
            {
                System.Console.SetCursorPosition(cursorX, cursorY);

                for (int col = 1; col < 10; col++)
                {
                    if (currentFigure.Name == Names.Pawn)
                    {
                        FigureVisualisation pawn = new FigureVisualisation();

                        if (pawn.Pawn[row, col] != ' ')
                        {
                            if (currentFigure.Color == Colors.Black)
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.Black;
                            }
                            else
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.White;
                            }
                            System.Console.Write(' ');
                        }
                        else
                        {
                            System.Console.BackgroundColor = color;
                            System.Console.Write(' ');
                        }
                        //System.Console.Write(pawn.Pawn[row, col]);
                    }
                    else if (currentFigure.Name == Names.Knight)
                    {
                        FigureVisualisation knight = new FigureVisualisation();

                        if (knight.Knight[row, col] != ' ')
                        {
                            if (currentFigure.Color == Colors.Black)
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.Black;
                            }
                            else
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.White;
                            }
                            System.Console.Write(' ');
                        }
                        else
                        {
                            System.Console.BackgroundColor = color;
                            System.Console.Write(' ');
                        }

                        //System.Console.Write(knight.Knight[row, col]);
                    }
                    else if (currentFigure.Name == Names.Bishop)
                    {
                        FigureVisualisation bishop = new FigureVisualisation();

                        if (bishop.Bishop[row, col] != ' ')
                        {
                            if (currentFigure.Color == Colors.Black)
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.Black;
                            }
                            else
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.White;
                            }
                            System.Console.Write(' ');
                        }
                        else
                        {
                            System.Console.BackgroundColor = color;
                            System.Console.Write(' ');
                        }

                        //System.Console.Write(bishop.Bishop[row, col]);
                    }
                    else if (currentFigure.Name == Names.Rook)
                    {
                        FigureVisualisation rook = new FigureVisualisation();

                        if (rook.Rook[row, col] != ' ')
                        {
                            if (currentFigure.Color == Colors.Black)
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.Black;
                            }
                            else
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.White;
                            }
                            System.Console.Write(' ');
                        }
                        else
                        {
                            System.Console.BackgroundColor = color;
                            System.Console.Write(' ');
                        }

                        //System.Console.Write(rook.Rook[row, col]);
                    }
                    else if (currentFigure.Name == Names.Queen)
                    {
                        FigureVisualisation queen = new FigureVisualisation();

                        if (queen.Queen[row, col] != ' ')
                        {
                            if (currentFigure.Color == Colors.Black)
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.Black;
                            }
                            else
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.White;
                            }
                            System.Console.Write(' ');
                        }
                        else
                        {
                            System.Console.BackgroundColor = color;
                            System.Console.Write(' ');
                        }

                        //System.Console.Write(queen.Queen[row, col]);
                    }
                    else if (currentFigure.Name == Names.King)
                    {
                        FigureVisualisation king = new FigureVisualisation();

                        if (king.King[row, col] != ' ')
                        {
                            if (currentFigure.Color == Colors.Black)
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.Black;
                            }
                            else
                            {
                                System.Console.BackgroundColor = System.ConsoleColor.White;
                            }
                            System.Console.Write(' ');
                        }
                        else
                        {
                            System.Console.BackgroundColor = color;
                            System.Console.Write(' ');
                        }

                        //System.Console.Write(king.King[row, col]);
                    }
                    else
                    {
                        FigureVisualisation empty = new FigureVisualisation();

                        System.Console.Write(empty.Empty[row, col]);
                    }
                }

                cursorY += 1;
                System.Console.WriteLine();
            }
        }
    }
}
