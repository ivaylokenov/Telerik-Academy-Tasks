using System;
using System.Text;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Cards.Count; i++)
            {
                result.Append("(");
                result.Append(Cards[i].ToString());
                result.Append(")");
            }

            return result.ToString();
        }
    }
}
