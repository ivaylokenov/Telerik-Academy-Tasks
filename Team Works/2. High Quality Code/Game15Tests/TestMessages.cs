using System;
using GameFifteen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Game15Tests
{
    [TestClass]
    public class TestMessages
    {
        [TestMethod]
        public void TestCellDoesNotExist()
        {
            string expected = "That cell does not exist in the matrix.";
            string result = Messages.GetCellDoesNotExistMessage();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIllegalCommand()
        {
            string expected = "Illegal command!";
            string result = Messages.GetIllegalCommandMessage();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestIllegalMove()
        {
            string expected = "Illegal move!";
            string result = Messages.GetIllegalMoveMessage();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestNextMove()
        {
            string expected = "Enter a number to move: ";
            string result = Messages.GetNextMoveMessage();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.AppendLine("Welcome to the Game \"15\".");
            welcomeMessage.AppendLine("Please try to arrange the numbers sequentially.");
            welcomeMessage.AppendLine("Menu:");
            welcomeMessage.AppendLine("top - view the top scoreboard");
            welcomeMessage.AppendLine("restart - start a new game");
            welcomeMessage.Append("exit - quit the game");

            string expected = welcomeMessage.ToString();
            string result = Messages.GetWelcomeMessage();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCongratsMessage()
        {
            string expected = "Congratulations! You won the game in 4 moves.";
            string result = Messages.GetCongratsMessage("4 moves");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSorrowMessage()
        {
            string expected = "You couldn't get in the top 100 scoreboard.";
            string result = Messages.GetSorrowMessage(100);
            Assert.AreEqual(expected, result);
        }
    }
}
