using CardGames;
using System;
using Xunit;

namespace SnapTests
{
    public class GameOverTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        public void GameOver(int players)
        {
            TestPack pack = new TestPack();

            SnapGame game = new SnapGame(pack, players);

            while(!game.GameOver)
            {
                game.TakeTurn();
                game.TakeTurn();
                game.SnapWithWinner(0);

                if (game.Turns > 100) throw (new Exception("Taking too many turns."));
            }

            Assert.Equal(52, game.Players[0].FaceDownPile.Count);
            Assert.Equal(52, game.Turns);
        }
    }
}
