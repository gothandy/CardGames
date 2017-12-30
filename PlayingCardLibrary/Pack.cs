using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    public class Pack
    {
        public int Count => 52;

        public Card this[int index] => new Card(Rank.Ace, Suit.Spade);
    }
}