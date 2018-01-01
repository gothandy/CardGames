﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public class Pile : IEnumerable<Card>
    {
        protected List<Card> cards = new List<Card>();

        private Orientation orientation;

        public Pile(Orientation orientation)
        {
            this.orientation = orientation;
        }

        public Orientation Orientation => orientation;

        public bool Empty => cards.Count == 0;

        public int Count => cards.Count;

        public Card TopCard => cards[cards.Count - 1];

        public Card this[int index] => cards[index];

        internal void Add(Card card)
        {
            cards.Add(card);
        }

        public void PlaceTopCard(Pile pile)
        {
            pile.Add(this.TopCard);

            cards.RemoveAt(cards.Count - 1);
        }

        public void AddToBottom(Pile pile)
        {
            cards.InsertRange(0, pile);
            pile.RemoveAll();
        }

        protected void RemoveAll()
        {
            cards.RemoveAll(c => true);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)cards).GetEnumerator();
        }

        public void Flip()
        {
            cards.Reverse();
            orientation = (Orientation)(((int)orientation + 1) % 2);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)cards).GetEnumerator();
        }
    }
}