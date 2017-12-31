using PlayingCardLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamesTest
{
    public class TestPack : Pile
    {
        public TestPack() : base(Orientation.FaceDown)
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }
    }
}
