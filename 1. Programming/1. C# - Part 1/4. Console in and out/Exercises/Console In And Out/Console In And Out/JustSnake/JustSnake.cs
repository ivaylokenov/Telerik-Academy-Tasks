using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustSnake
{
    struct Position
    {
        public int row;
        public int col;
        //dve promenlivi za koordinati, koito sa 4ast ot strukturata Position
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class JustSnake
    {
        static void Main(string[] args)
        {
            Position[] directions = new Position[]
            {
                new Position(0, 1), //nadqsno
                new Position(0, -1), //nalqvo
                new Position(1, 0), //nadolu
                new Position(-1, 0), //nagore
            };
            int sleepTime = 100;
            int direction = 0; //pazim teku6tata poziciq s koqto dvijim nashata zmiq
            Console.CursorVisible = false;
            Random randomNumberGenerator = new Random(); //syzdava random 4isla
            Console.BufferHeight = Console.WindowHeight; //maha skrolera
            Position food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth)); //syzdavame hrana 

            Queue<Position> SnakeElements = new Queue<Position>(); //opa6ka izpolzvame q za zmiqta
            for (int i = 0; i < 6; i++)
            {
                SnakeElements.Enqueue(new Position(0, i));
            }

            foreach (Position position in SnakeElements) //vizualizira ot masiva elementite vednaga sled kato startirame
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.Write('*');
            }

            Console.SetCursorPosition(food.col, food.row); //vizualizirame hranata
            Console.Write('@');

            while (true) //while true pravi cikyla bezkraen, takyv ni trqbva za igrata
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey(); //vyvejdaneto ot potrebitelq i posokite na zmiqta
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != 0) direction = 1;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != 1) direction = 0;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != 2) direction = 3;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != 3) direction = 2;
                    }
                }
                foreach (Position position in SnakeElements) //vizualizira ot masiva elementite
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write('*');
                }

                Position snakeHead = SnakeElements.Last(); //vzima glavata na zmiqta, koqto e posleden element ot masiva
                Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

                if (snakeNewHead.row < 0 || snakeNewHead.col < 0 || snakeNewHead.row >= Console.WindowHeight || snakeNewHead.col >= Console.WindowWidth || SnakeElements.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("GAME OVER!\n\rScore: {0}\n\r", (SnakeElements.Count - 6) * 100);
                    return;
                }

                SnakeElements.Enqueue(snakeNewHead); //smenq glavata na zmiqta taka 4e tq da se dviji
                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                Console.Write('*');

                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    do
                    {
                        food = new Position(randomNumberGenerator.Next(0, Console.WindowHeight), randomNumberGenerator.Next(0, Console.WindowWidth)); //syzdavame hrana kogato starata e izqdena
                    }
                    while (SnakeElements.Contains(food));
                    sleepTime -= 2;
                }
                else
                {
                    Position last = SnakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }

                Console.SetCursorPosition(food.col, food.row); //vizualizirame hranata
                Console.Write('@');
                Thread.Sleep(sleepTime); //da iz4akva 100 milisekundi vseki pyt
            }
        }
    }
}
