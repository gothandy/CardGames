using CardGames;
using System;
using Xunit;

namespace CardGames
{
    public class PlayerTests
    {

        [Fact]
        public void NewPlayer()
        {
            TestPlayer player = new TestPlayer();

            Assert.True(player.Hand.Empty);
        }

        [Fact]
        public void NewPlayers()
        {
            TestGame game = new TestGame(2, 3);

            Assert.Equal(2, game.Players.Count);
        }
    }
}
