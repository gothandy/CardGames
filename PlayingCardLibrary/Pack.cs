using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    public class Pack
    {
        List<Card> cards = new List<Card>();



        public int Count => cards.Count;

        public Card this[int index] => cards[index];
    }
}