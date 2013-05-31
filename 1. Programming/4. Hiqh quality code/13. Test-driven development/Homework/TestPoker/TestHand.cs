using System;
using Poker;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPoker
{
    [TestClass]
    public class TestHand
    {
        // ♣
        // ♦
        // ♥
        // ♠

        [TestMethod]
        public void TestHandToString()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            string expected = "(A♣)(A♦)(K♥)(K♠)(7♦)";
            string result = hand.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestHandToStringAgain()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            string expected = "(2♣)(A♦)(10♥)(K♠)(7♦)";
            string result = hand.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
