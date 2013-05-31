using System;
using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPoker
{
    // ♣
    // ♦
    // ♥
    // ♠

    [TestClass]
    public class TestCard
    {
        [TestMethod]
        public void TestToStringTwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringTenDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringAceSpades() //motorhead fans: ace of spades :D
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringJackHearts()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Hearts);
            string expected = "J♥";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestToStringQueenHearts()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Hearts);
            string expected = "Q♥";
            string result = card.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
