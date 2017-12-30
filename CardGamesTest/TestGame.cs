using PlayingCardLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGamesTest
{
    public class TestGame : Game<TestPlayer>
    {
        public TestGame(int playerCount) : base(playerCount)
        {
            Pack pack = new Pack();

            this.Deal(pack, p => p.Hand, numberOfCards: 3);
        }
    }
}
