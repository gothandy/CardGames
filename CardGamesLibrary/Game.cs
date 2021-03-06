﻿using CardGames;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CardGames
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

        public void Deal(Pile pile, Func<T, Pile> pileToDealTo, int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                foreach (T player in players)
                {
                    pile.PlaceTopCardOn(pileToDealTo.Invoke(player));
                }
            }
        }

        public void DealAll(Pile pile, Func<T, Pile> pileToDealTo)
        {
            TurnTaker<T> turnTaker = new TurnTaker<T>(players);

            while (!pile.Empty)
            {
                pile.PlaceTopCardOn(pileToDealTo.Invoke(turnTaker.CurrentPlayer));

                turnTaker.NextPlayer();
            }
        }

        public ReadOnlyCollection<T> Players => players.AsReadOnly();

    }
}