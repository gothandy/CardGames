using System;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    public class Pile
    {
        List<Card> cards = new List<Card>();

        public Orientation Orientation;

        public Pile(Orientation orientation)
        {
            this.Orientation = orientation;
        }

        public bool Empty => cards.Count == 0;

        public int Count => cards.Count;

        public Card this[int index] => cards[index];

        internal void Add(Card card)
        {
            cards.Add(card);
        }
    }
}