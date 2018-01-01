using System;
using System.Collections.Generic;

namespace CardGames
{
    public class TurnTaker<T>
    {
        private IEnumerator<T> playersEnumerator;

        public TurnTaker(IEnumerable<T> players)
        {
            this.playersEnumerator = players.GetEnumerator();
            playersEnumerator.MoveNext();
        }

        public T CurrentPlayer => playersEnumerator.Current;

        public void NextPlayer()
        {
            if (!playersEnumerator.MoveNext())
            {
                playersEnumerator.Reset();
                playersEnumerator.MoveNext();
            }
        }
    }
}