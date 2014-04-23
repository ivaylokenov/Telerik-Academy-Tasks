using System;
using GameFifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Game15Tests
{
    [TestClass]
    public class TestConsoleRenderer
    {
        [TestMethod]
        public void TestRenderMessage()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            using (writer)
            {
                renderer.RenderMessage(Messages.GetGoodbye());
            }

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("Good bye!");

            Assert.AreEqual(expected.ToString(), writer.ToString());
        }

        [TestMethod]
        public void TestRenderMatrix()
        {
            ConsoleRenderer renderer = new ConsoleRenderer();
            Board gameBoard = new Board(4, 4);
            gameBoard.InitializeMatrix();

            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            using (writer)
            {
                renderer.RenderMatrix(gameBoard);
            }

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("  ------------- ");
            expected.AppendLine(" |  1  2  3  4 |");
            expected.AppendLine(" |  5  6  7  8 |");
            expected.AppendLine(" |  9 10 11 12 |");
            expected.AppendLine(" | 13 14 15    |");
            expected.AppendLine("  ------------- ");

            Assert.AreEqual(expected.ToString(), writer.ToString());
        }
    }
}