using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class SnapTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void NewGame(int player)
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, numberOfCards: 26);

            Assert.Equal(26, snapPlayers[player].Hand.Count);

        }
    }
}
