using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
{

    public class Players<T> : IEnumerable<T> where T : new()
    {
        private List<T> players = new List<T>();

        public Players(int playerCount)
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
        
        public int Count => players.Count;

        public T this[int index] => players[index];


        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)players).GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Player>)players).GetEnumerator();
        }
    }
}