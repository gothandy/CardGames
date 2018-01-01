using CardGames;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGames
{
    public class TestGame : Game<TestPlayer>
    {
        public TestGame(int playerCount, int numberOfCards) : base(playerCount)
        {
            TestPack pack = new TestPack();

            this.Deal(pack, p => p.Hand, numberOfCards);
        }
    }
}
