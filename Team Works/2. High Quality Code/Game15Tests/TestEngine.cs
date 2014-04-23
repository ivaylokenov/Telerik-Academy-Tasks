using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen;
using System.IO;
using System.Text;

namespace Game15Tests
{
    [TestClass]
    public class TestEngine
    {
        [TestMethod]
        public void TestPlayGameWithCommandExitAndSimpleGameplay()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Board gameBoard = new Board(3, 3);
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            gameBoard.InitializeMatrix();
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("6\n6\nrado\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5    |");
            expectedOutput.AppendLine(" |  7  8  6 |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Congratulations! You won the game in 2 moves.");
            expectedOutput.AppendLine("Please enter your name for the top scoreboard: ");
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        public void TestPlayGameWithCommandRestart()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Board gameBoard = new Board(3, 3);
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            gameBoard.InitializeMatrix();
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("restart\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringWriter expectedMatrixAfterRestart = new StringWriter();

            using (expectedMatrixAfterRestart)
            {
                Console.SetOut(expectedMatrixAfterRestart);
                renderer.RenderMatrix(engine.Board);
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.Append(expectedMatrixAfterRestart.ToString());
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        public void TestPlayGameWithCommandTop()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Board gameBoard = new Board(3, 3);
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            gameBoard.InitializeMatrix();
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("top\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringWriter expectedTopScores = new StringWriter();

            using (expectedTopScores)
            {
                Console.SetOut(expectedTopScores);
                renderer.RenderTopScores(playerScore);
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.Append(expectedTopScores.ToString());
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        public void TestPlayGameWithAnIllegalMove()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            Board gameBoard = new Board(3, 3);
            gameBoard.InitializeMatrix();
            gameBoard.Matrix[0, 0] = "2";
            gameBoard.Matrix[0, 1] = "1";
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("1\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  2  1  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Illegal move!");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        public void TestPlayGameWithSimpleGameplayWithNoHighScore()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            Board gameBoard = new Board(3, 3);
            gameBoard.InitializeMatrix();
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("6\n3\n3\n6\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5    |");
            expectedOutput.AppendLine(" |  7  8  6 |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2    |");
            expectedOutput.AppendLine(" |  4  5  3 |");
            expectedOutput.AppendLine(" |  7  8  6 |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5    |");
            expectedOutput.AppendLine(" |  7  8  6 |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Congratulations! You won the game in 4 moves.");
            expectedOutput.AppendLine("You couldn't get in the top 5 scoreboard.");
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        public void TestPlayGameWithIllegalCommand()
        {
             ConsoleRenderer renderer = new ConsoleRenderer();
            Board gameBoard = new Board(3, 3);
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            gameBoard.InitializeMatrix();
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("asd\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  1  2  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Illegal command!");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

        [TestMethod]
        public void TestPlayGameWithNonExistingCell()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Score playerScore = new Score("Anonymous", 0, 5, "top.txt");
            Board gameBoard = new Board(3, 3);
            gameBoard.InitializeMatrix();
            gameBoard.Matrix[0, 0] = "2";
            gameBoard.Matrix[0, 1] = "1";
            Engine engine = new Engine(renderer, gameBoard, playerScore);

            StringReader input = new StringReader("11\nexit");
            StringWriter output = new StringWriter();

            using (input)
            {
                using (output)
                {
                    Console.SetIn(input);
                    Console.SetOut(output);
                    engine.PlayGame();
                }
            }

            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Welcome to the Game \"15\".");
            expectedOutput.AppendLine("Please try to arrange the numbers sequentially.");
            expectedOutput.AppendLine("Menu:");
            expectedOutput.AppendLine("top - view the top scoreboard");
            expectedOutput.AppendLine("restart - start a new game");
            expectedOutput.AppendLine("exit - quit the game");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine(" |  2  1  3 |");
            expectedOutput.AppendLine(" |  4  5  6 |");
            expectedOutput.AppendLine(" |  7  8    |");
            expectedOutput.AppendLine("  ---------- ");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("That cell does not exist in the matrix.");
            expectedOutput.AppendLine("Enter a number to move: ");
            expectedOutput.AppendLine("Good bye!");

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }
    }
}