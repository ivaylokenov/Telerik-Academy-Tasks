using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JustPingPong
{
    class JustPingPong
    {
        static int firstPlayerPadSize = 6;
        static int secondPlayerPadSize = 6;
        static int ballPositionX = 0;
        static int ballPositionY = 0;
        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;
        static int firstPlayerResult = 0;
        static int secondPlayerResult = 0;
        static Random randomGenerator = new Random();
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;
        static int difficulty;

        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '|');
                PrintAtPosition(1, y, '|');
            }
        }

        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '|');
                PrintAtPosition(Console.WindowWidth - 2, y, '|');
            }

        }

        static void SetInitialPositions()
        {
            firstPlayerPosition = Console.WindowHeight / 2 - firstPlayerPadSize / 2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            SetBallAtTheMiddle();
        }

        static void SetBallAtTheMiddle()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }

        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }

        static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
            Console.WriteLine("{0}-{1}", firstPlayerResult, secondPlayerResult);
        }

        static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition + firstPlayerPadSize < Console.WindowHeight)
            {
                firstPlayerPosition++;
            }
        }

        static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
        }

        static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition + secondPlayerPadSize < Console.WindowHeight)
            {
                secondPlayerPosition++;
            }
        }

        static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }
        }

        static void SecondPlayerAIMove()
        {
            int randomNumber = randomGenerator.Next(1, 101);
            //if (randomNumber == 0)
            //{
            //    MoveSecondPlayerUp();
            //}
            //else
            //{
            //    MoveSecondPlayerDown();
            //}
            if (randomNumber < difficulty)
            {
                if (ballDirectionUp == true)
                {
                    MoveSecondPlayerUp();
                }
                else
                {
                    MoveSecondPlayerDown();
                }
            }
        }

        static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                ballDirectionUp = false;
            }
            if (ballPositionY == Console.WindowHeight - 1)
            {
                ballDirectionUp = true;
            }

            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallAtTheMiddle();
                ballDirectionRight = false;
                ballDirectionUp = true;
                firstPlayerResult++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2);
                Console.Write("First player wins!");
                Console.ReadKey();
            }

            if (ballPositionX == 0)
            {
                SetBallAtTheMiddle();
                ballDirectionRight = true;
                ballDirectionUp = true;
                secondPlayerResult++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2);
                Console.Write("Second player wins!");
                Console.ReadKey();
            }

            if (ballPositionX < 3)
            {
                if (ballPositionY >= firstPlayerPosition && ballPositionY <= firstPlayerPosition + firstPlayerPadSize)
                {
                    ballDirectionRight = true;
                }
            }

            if (ballPositionX > Console.WindowWidth - 4)
            {
                if (ballPositionY >= secondPlayerPosition && ballPositionY <= secondPlayerPosition + secondPlayerPadSize)
                {
                    ballDirectionRight = false;
                }
            }

            if (ballDirectionUp == true)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }

            if (ballDirectionRight == true)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }

        static void Main()
        {
            RemoveScrollBars();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 - 4);
            Console.WriteLine("PING PONG");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 - 2);
            Console.WriteLine("Enter difficulty:");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 - 1);
            Console.WriteLine("1 - Easy");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2);
            Console.WriteLine("2 - Medium");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 1);
            Console.WriteLine("3 - Hard");
            ConsoleKeyInfo level = Console.ReadKey();
            do
            {
                if (level.Key == ConsoleKey.D1)
                {
                    difficulty = 50;
                }
                else if (level.Key == ConsoleKey.D2)
                {
                    difficulty = 70;
                }
                else if (level.Key == ConsoleKey.D3)
                {
                    difficulty = 90;
                }
            }
            while (level.Key != ConsoleKey.D1 && level.Key != ConsoleKey.D2 && level.Key != ConsoleKey.D3);
            SetInitialPositions();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();
                    }
                }
                SecondPlayerAIMove();
                MoveBall();
                Console.Clear();
                DrawFirstPlayer();
                DrawSecondPlayer();
                DrawBall();
                PrintResult();
                Thread.Sleep(60);
            }
        }
    }
}
