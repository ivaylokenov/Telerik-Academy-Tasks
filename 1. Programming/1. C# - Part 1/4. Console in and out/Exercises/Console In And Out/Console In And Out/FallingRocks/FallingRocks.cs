using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FallingRocks
{
    class FallingRocks
    {
        struct Position
        {
            public int X, Y;
            public char Symbol;
            public ConsoleColor Color;
            public Position(int x, int y, char Symbol, ConsoleColor Color)
            {
                this.X = x;
                this.Y = y;
                this.Symbol = Symbol;
                this.Color = Color;
            }
        }

        static void Main()
        {
            string label;
            Console.CursorVisible = false;
            Console.BufferHeight = Console.WindowHeight;

            while (true)
            {
                int rocksNumber = 0;
                int sleepTime = 0;

                Console.Clear();

                while (true)
                {
                    label = "FALLING ROCKS";
                    Console.SetCursorPosition((Console.WindowWidth / 2 - label.Length / 2), Console.WindowHeight / 2 - 3);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(label);
                    Console.ForegroundColor = ConsoleColor.White;
                    label = "Game Difficulty:";
                    Console.SetCursorPosition((Console.WindowWidth / 2 - label.Length / 2), Console.WindowHeight / 2 - 1);
                    Console.Write(label);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    label = "1 - Easy";
                    Console.SetCursorPosition((Console.WindowWidth / 2 - label.Length / 2), Console.WindowHeight / 2);
                    Console.Write(label);
                    Console.ForegroundColor = ConsoleColor.Green;
                    label = "2 - Medium";
                    Console.SetCursorPosition((Console.WindowWidth / 2 - label.Length / 2) + 1, Console.WindowHeight / 2 + 1);
                    Console.Write(label);
                    Console.ForegroundColor = ConsoleColor.Red;
                    label = "3 - Hard";
                    Console.SetCursorPosition((Console.WindowWidth / 2 - label.Length / 2), Console.WindowHeight / 2 + 2);
                    Console.Write(label);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo menuChoice = Console.ReadKey();
                        if (menuChoice.Key == ConsoleKey.D1)
                        {
                            rocksNumber = 30;
                            sleepTime = 150;
                            break;
                        }
                        if (menuChoice.Key == ConsoleKey.D2)
                        {
                            rocksNumber = 60;
                            sleepTime = 100;
                            break;
                        }
                        if (menuChoice.Key == ConsoleKey.D3)
                        {
                            rocksNumber = 90;
                            sleepTime = 75;
                            break;
                        }
                    }
                }
                Console.Clear();

                char[] rockSymbols = new char[10] { '+', '-', 'X', '%', '^', '*', '!', '=', '?', '#' };
                sbyte slowRocks = 1;
                double score = 0;
                int finalScore = 0;
                Random randomGenerator = new Random();
                Position[] rocks = new Position[rocksNumber];

                Position dwarf = new Position();
                dwarf.X = Console.WindowWidth / 2;
                dwarf.Y = Console.WindowHeight - 1;

                for (int i = 0; i < rocksNumber; i++)
                {
                    rocks[i].X = randomGenerator.Next(1, Console.WindowWidth - 1);
                    rocks[i].Y = randomGenerator.Next(1, Console.WindowHeight - 10);
                    rocks[i].Color = (ConsoleColor)randomGenerator.Next(10, 16);
                    rocks[i].Symbol = rockSymbols[randomGenerator.Next(1, rockSymbols.Length)];
                }

                while (true)
                {
                    if (slowRocks > 0)
                    {
                        for (int i = 0; i < rocksNumber; i++)
                        {
                            if (rocks[i].Y == (Console.WindowHeight - 1))
                            {
                                Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                                Console.Write(" ");
                                rocks[i].X = randomGenerator.Next(1, (Console.WindowWidth - 1));
                                rocks[i].Y = randomGenerator.Next(0, 3);
                                rocks[i].Color = (ConsoleColor)randomGenerator.Next(10, 16);
                                rocks[i].Symbol = rockSymbols[randomGenerator.Next(1, rockSymbols.Length)];
                            }
                            else
                            {
                                Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                                Console.Write(" ");
                                rocks[i].Y++;
                            }
                            Console.SetCursorPosition(rocks[i].X, rocks[i].Y);
                            Console.ForegroundColor = rocks[i].Color;
                            Console.Write(rocks[i].Symbol);
                        }
                    }

                    if (Console.KeyAvailable && dwarf.X < Console.WindowWidth && dwarf.X > 0)
                    {
                        Console.SetCursorPosition(dwarf.X - 1, dwarf.Y);
                        Console.Write(" " + " " + " ");
                        ConsoleKeyInfo pressedKey = Console.ReadKey();
                        if (pressedKey.Key == ConsoleKey.RightArrow) dwarf.X++;
                        if (pressedKey.Key == ConsoleKey.LeftArrow) dwarf.X--;
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(dwarf.X - 1, dwarf.Y);
                    Console.Write("\\0/");

                    for (int i = 0; i < rocksNumber; i++)
                    {
                        if (((dwarf.X == rocks[i].X) && (dwarf.Y == rocks[i].Y)) ||
                            ((dwarf.X == rocks[i].X - 1) && (dwarf.Y == rocks[i].Y)) ||
                            ((dwarf.X == rocks[i].X + 1) && (dwarf.Y == rocks[i].Y)))
                        {
                            Console.SetCursorPosition(dwarf.X - 1, dwarf.Y);
                            Console.Write("\\0/");
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                                Console.WriteLine("GAME OVER!");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 + 2);
                                if (sleepTime == 150)
                                {
                                    label = "Easy";
                                }
                                if (sleepTime == 100)
                                {
                                    label = "Medium";
                                }
                                if (sleepTime == 75)
                                {
                                    label = "Hard";
                                }
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("Your score is {0} points on {1} difficulty!", finalScore, label);
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 13, Console.WindowHeight / 2 + 4);
                                Thread.Sleep(2000);
                                Console.ForegroundColor = ConsoleColor.White;
                                return;

                            }
                        }
                    }

                    Thread.Sleep(sleepTime);
                    slowRocks *= -1;
                    score += 1;
                    finalScore = (int)score;
                }
            }
        }
    }
}

