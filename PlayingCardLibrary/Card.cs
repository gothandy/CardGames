using System;

namespace PlayingCardLibrary
{
    public class Card
    {
        private Rank rank;
        private Suit suit;

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}s", this.rank, this.suit);
        }
    }
}
