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
            // Keep the cards the facing the same way when adding
            if (orientation != pile.Orientation) pile.Flip();

            cards.InsertRange(0, pile);
            pile.RemoveAll();
        }

        protected void RemoveAll()
        {
            cards.RemoveAll(c => true);
        }

        public void Flip()
        {
            cards.Reverse();
            orientation = FlipOrientation();
        }

        public void Shuffle(int numberOfTimes)
        {
            Random random = new Random();

            for (int i = 0; i < numberOfTimes; i++)
            {
                RandomCardSwap(random);
            }
        }

        private void RandomCardSwap(Random random)
        {
            int from = random.Next(cards.Count);
            int to = RandomNotEqualTo(random, from);

            Swap(from, to);
        }

        public void Swap(int from, int to)
        {
            Card card = cards[from];
            cards[from] = cards[to];
            cards[to] = card;
        }

        private int RandomNotEqualTo(Random random, int from)
        {
            while (true)
            {
                int to = random.Next(cards.Count);

                if (to != from) return to;
            }
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