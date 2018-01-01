using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGames
{
    public class Pack : Pile
    {

        public Pack() : base(Orientation.FaceDown)
        {

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
        }



    }
}