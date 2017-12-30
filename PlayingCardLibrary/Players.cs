using System;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    public class Players
    {
        private List<Player> players = new List<Player>();

        public Players(int playerCount)
        {
            for (int i =0; i< playerCount; i++)
            {
                players.Add(new Player());
            }
        }

        public int Count => players.Count;

        public Player this[int index] => players[index];
    }
}