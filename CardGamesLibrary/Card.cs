using System;

namespace PlayingCardLibrary
{
    public class Card
    {
        public Rank Rank;
        public Suit Suit;

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}s", this.Rank, this.Suit);
        }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Card)) return false;

            Card cardToCompare = (Card)obj;

            return (cardToCompare.Rank == this.Rank) && (cardToCompare.Suit == this.Suit);
        }

        public override int GetHashCode()
        {
            int countOfSuits = Enum.GetValues(typeof(Suit)).Length;

            return (int)this.Rank + ((int)this.Suit * countOfSuits);
        }
    }
}
