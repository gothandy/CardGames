using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
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

        public void PlaceTopCard(Pile pile)
        {
            int index = cards.Count - 1;

            Card card = cards[index];

            pile.Add(card);

            cards.RemoveAt(index);
        }

        public void Deal(Players<Player> players, int numberOfCards)
        {
            for(int i = 0; i < numberOfCards; i++)
            {
                foreach(Player player in players)
                {
                    PlaceTopCard(player.Hand);
                }
            }
        }
    }
}