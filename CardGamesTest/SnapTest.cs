using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class SnapTest
    {
        [Fact]
        public void NewGame()
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, cardCount: 26);

        }
    }
}
