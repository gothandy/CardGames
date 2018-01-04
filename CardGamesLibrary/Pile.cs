using CardGamesLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        public Card TopCard
        {
            get
            {
                if (cards.Count == 0) return null;
                return cards[cards.Count - 1];
            }
        }

        public Card this[int index] => cards[index];
        
        internal void Add(Card card)
        {
            cards.Add(card);
        }

        public void PlaceTopCardOn(Pile pile)
        {
            if (cards.Count == 0) throw (new EmptyPileException());

            pile.Add(TopCard);

            cards.RemoveAt(cards.Count - 1);
        }

        public void AddToBottomOf(Pile pile)
        {
            if (cards.Count == 0) throw (new EmptyPileException());

            // Keep the cards the facing the same way when adding
            if (orientation != pile.Orientation) Flip();

            pile.InsertRange(0, cards);
            cards.RemoveAll(c => true);
        }

        protected void InsertRange(int index, IEnumerable<Card> collection)
        {
            cards.InsertRange(index, collection);
        }

        public void Flip()
        {
            cards.Reverse();
            orientation = FlipOrientation();
        }

        public void Swap(int from, int to)
        {
            Card card = cards[from];
            cards[from] = cards[to];
            cards[to] = card;
        }

        private Orientation FlipOrientation()
        {
            return (Orientation)(((int)orientation + 1) % 2);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return ((IEnumerable<Card>)cards).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Card>)cards).GetEnumerator();
        }
    }
}

