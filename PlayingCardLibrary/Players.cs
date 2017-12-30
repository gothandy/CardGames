using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    // Default to Player Type.
    public class Players : Players<Player>
    {
        public Players(int playerCount) : base(playerCount)
        {
        }
    }

    public class Players<T> : IEnumerable<T> where T : Player, new()
    {
        private List<T> players = new List<T>();

        public Players(int playerCount)
        {
            for (int i =0; i< playerCount; i++)
            {
                players.Add(new T());
            }
        }

        public void Deal(Pack pack, int numberOfCards)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                foreach (Player player in players)
                {
                    pack.PlaceTopCard(player.Hand);
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