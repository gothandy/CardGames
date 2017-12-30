﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    public class Pack
    {
        List<Card> cards = new List<Card>();

        public Pack()
        {
            foreach(Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        public int Count => cards.Count;

        public Orientation Orientation => Orientation.FaceDown;

        public Card this[int index] => cards[index];
    }
}