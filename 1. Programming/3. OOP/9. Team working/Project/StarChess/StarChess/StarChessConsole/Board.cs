namespace StarChessConsole
{
    class Board : Interfaces.IBoard
    {
        private readonly Field[,] fullBoard = new Field[8, 8];

        private void FieldColorChanger() //changes color of Black
        {
            System.Console.ForegroundColor = System.ConsoleColor.Black;
            if (System.Console.BackgroundColor == System.ConsoleColor.Gray)
            {
                System.Console.BackgroundColor = System.ConsoleColor.DarkGray;
            }
            else
            {
                System.Console.BackgroundColor = System.ConsoleColor.Gray;
            }
        }

        public void PrintBoard(FigurePositions currentPosition) //prints entire board
        {
            System.Console.SetCursorPosition(37, 0);
            System.Console.BackgroundColor = System.ConsoleColor.Black;
            System.Console.WriteLine("STAR CHESS");

            CursorCoordinates currentCursor = new CursorCoordinates();
            currentCursor.X = 6;
            currentCursor.Y = 6;

            System.Console.BackgroundColor = System.ConsoleColor.White;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    FieldColorChanger();

                    System.Console.SetCursorPosition(currentCursor.X, currentCursor.Y);
                    fullBoard[i, j] = new Field();
                    fullBoard[i, j].PrintField(currentCursor.X, currentCursor.Y, currentPosition.Position[i, j], System.Console.BackgroundColor);
                    currentCursor.X += 9;
                }

                FieldColorChanger();

                currentCursor.X = 6;
                currentCursor.Y += 5;
            }

            //Print board indicators
            System.Console.BackgroundColor = System.ConsoleColor.Black;
            System.Console.ForegroundColor = System.ConsoleColor.White;
            char[] arrayOfLetters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            int counter = 0;

            for (int i = 10; i < 74; i += 9)
            {
                System.Console.SetCursorPosition(i, 4);
                System.Console.Write(arrayOfLetters[counter]);
                System.Console.SetCursorPosition(i, 47);
                System.Console.Write(arrayOfLetters[counter]);
                counter++;
            }

            counter = 8;

            for (int i = 8; i < 44; i += 5)
            {
                System.Console.SetCursorPosition(3, i);
                System.Console.Write(counter);
                System.Console.SetCursorPosition(81, i);
                System.Console.Write(counter);
                counter--;
            }

            //print board boarders o.O
            System.Console.BackgroundColor = System.ConsoleColor.DarkGray;

            for (int i = 2; i < 82; i++)
            {
                PrintBorders(i, 3);
                PrintBorders(i, 48);
            }

            for (int i = 4; i < 80; i++)
            {
                PrintBorders(i, 5);
                PrintBorders(i, 46);
            }

            for (int i = 3; i < 49; i++)
            {
                PrintBorders(1, i);
                PrintBorders(82, i);
            }

            for (int i = 5; i < 47; i++)
            {
                PrintBorders(4, i);
                PrintBorders(5, i);
            }

            for (int i = 5; i < 47; i++)
            {
                PrintBorders(79, i);
                PrintBorders(78, i);
            }
        }

        private void PrintBorders(int x, int y)//prints borders
        {
            System.Console.SetCursorPosition(x, y); 
            System.Console.Write(' ');
        }
    }
}
