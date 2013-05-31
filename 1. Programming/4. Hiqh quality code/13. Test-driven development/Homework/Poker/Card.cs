using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string face = ((int)this.Face).ToString();
            switch (face)
            {
                case "11": face = "J"; break;
                case "12": face = "Q"; break;
                case "13": face = "K"; break;
                case "14": face = "A"; break;
                default:
                    break;
            }

            string suit = ((int)this.Suit).ToString();
            switch (suit)
            {
                case "1": suit = "♣"; break;
                case "2": suit = "♦"; break;
                case "3": suit = "♥"; break;
                case "4": suit = "♠"; break;
            }

            return face + suit;
        }
    }
}
