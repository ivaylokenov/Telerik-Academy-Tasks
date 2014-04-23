using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face && hand.Cards[i].Suit == hand.Cards[j].Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            // find min card
            int minCard = 15;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (minCard > (int)hand.Cards[i].Face)
                {
                    minCard = (int)hand.Cards[i].Face;
                }
            }

            if (minCard > 10)
            {
                return false;
            }

            bool hasFiveSequentCards = true;

            for (int i = minCard; i < minCard + 5; i++)
            {
                bool wasFound = false;

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == (int)hand.Cards[j].Face)
                    {
                        wasFound = true;
                        break;
                    }
                }

                if (!wasFound)
                {
                    hasFiveSequentCards = false;
                }
            }

            bool hasSameColors = true;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Suit != hand.Cards[j].Suit)
                    {
                        hasSameColors = false;
                        break;
                    }
                }

                if (hasSameColors)
                {
                    break;
                }
            }

            return hasFiveSequentCards && hasSameColors;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            int sameFaceCounter = 1;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = i + 1; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        sameFaceCounter++;
                    }
                }

                if (sameFaceCounter == 4)
                {
                    return true;
                }
                else
                {
                    sameFaceCounter = 1;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            int pairedHandsCount = 0;
            int threeHandsCount = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int sameCardCounter = 1;

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        sameCardCounter++;
                    }
                }

                if (sameCardCounter == 2)
                {
                    pairedHandsCount++;
                }
                if (sameCardCounter == 3)
                {
                    threeHandsCount++;
                }
            }

            //since each pair is counted three times in the loops we need to have 3 in our counter
            if (pairedHandsCount == 2 && threeHandsCount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            CardSuit suit = hand.Cards[0].Suit;

            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (suit != hand.Cards[i].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            // find min card
            int minCard = 15;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                if (minCard > (int)hand.Cards[i].Face)
                {
                    minCard = (int)hand.Cards[i].Face;
                }
            }

            if (minCard > 10)
            {
                return false;
            }

            bool hasFiveSequentCards = true;

            for (int i = minCard; i < minCard + 5; i++)
            {
                bool wasFound = false;

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == (int)hand.Cards[j].Face)
                    {
                        wasFound = true;
                        break;
                    }
                }

                if (!wasFound)
                {
                    hasFiveSequentCards = false;
                }
            }

            bool hasDifferentColors = false;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Suit != hand.Cards[j].Suit)
                    {
                        hasDifferentColors = true;
                        break;
                    }
                }

                if (hasFiveSequentCards)
                {
                    break;
                }
            }

            return hasFiveSequentCards && hasDifferentColors;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            int pairedHandsCount = 0;
            int threeHandsCount = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int sameCardCounter = 1;

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        sameCardCounter++;
                    }
                }

                if (sameCardCounter == 2)
                {
                    pairedHandsCount++;
                }
                if (sameCardCounter == 3)
                {
                    threeHandsCount++;
                }
            }

            //since each pair is counted three times in the loops we need to have 3 in our counter
            if (pairedHandsCount == 0 && threeHandsCount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsTwoPair(IHand hand)
        {
            int pairedHandsCount = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int sameCardCounter = 1;

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        sameCardCounter++;
                    }
                }

                if (sameCardCounter == 2)
                {
                    pairedHandsCount++;
                }
            }

            //since each pair is counted two times in the loops we need to have 4 in our counter
            if (pairedHandsCount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            int pairedHandsCount = 0;

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int sameCardCounter = 1;

                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (hand.Cards[i].Face == hand.Cards[j].Face)
                    {
                        sameCardCounter++;
                    }
                }

                if (sameCardCounter == 2)
                {
                    pairedHandsCount++;
                }
            }

            //since each pair is counted two times in the loops we need to have 2 in our counter
            if (pairedHandsCount == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            //I do not play poker so this makes sense for me :D
            if (this.IsStraightFlush(hand) || this.IsFourOfAKind(hand) || this.IsFullHouse(hand) 
                || this.IsFlush(hand) || this.IsStraight(hand) || this.IsThreeOfAKind(hand) 
                || this.IsTwoPair(hand) || IsOnePair(hand))
            {
                return false;
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
