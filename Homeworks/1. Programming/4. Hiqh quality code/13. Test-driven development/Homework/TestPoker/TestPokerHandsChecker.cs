using System;
using System.Collections.Generic;
using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPoker
{
    [TestClass]
    public class TestPokerHandsChecker
    {
        [TestMethod]
        public void TestValidHand()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestLessThanFiveCardsHand()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestTwoOfSameCard()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestTwoOfSameCardAgain()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestFourOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfAKindWithDifferentCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFalseFourOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFlushClubs()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestFlushSpades()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestFalseFlush()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestOnePair()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestOnePairWithDifferentCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestFalseOnePair()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestTwoPairs()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestTwoPairsDifferentCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestFalseTwoPairs()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestFalseTwoPairsDifferentCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestFalseThreeOfAKindWithFourSame()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestFalseThreeOfAKindWithAPair()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestFullHouse()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestFalseFullHouse()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestFalseFullHouseWithOtherCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestStraight()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestFalseStraightSameColor()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestFalseStraightNotSequentCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestFalseStraightFlushNotSequentCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestFalseStraightFlushNotSameColor()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestStraightFlush()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestIsHighCard()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestIsHighCardAnotherSetOfCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestFalseIsHighCardOnePair()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Spades),
            });

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }
    }
}
