using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PlayingCardLibrary
{

    public class Game<T> where T : new()
    {
        private List<T> players = new List<T>();

        public Game(int playerCount)
        {
            for (int i =0; i< playerCount; i++)
            {
                players.Add(new T());
            }
        }

        public void Deal(Pile pile, Func<T, Pile> lambda, int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                foreach (T player in players)
                {
                    pile.PlaceTopCard(lambda.Invoke(player));
                }
            }
        }

        public ReadOnlyCollection<T> Players => players.AsReadOnly();

    }
}