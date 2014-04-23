namespace GameFifteen
{
    using System;

    public class MainMethod
    {
        public static void Main()
        {
            ConsoleRenderer gameRenderer = new ConsoleRenderer();
            Board gameBoard = new Board(4, 4);
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");

            Engine engine = new Engine(gameRenderer, gameBoard, playerScore);

            engine.LoadBoard();

            engine.PlayGame();
        }
    }
}
