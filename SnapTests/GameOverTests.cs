using CardGames;
using System;
using Xunit;

namespace SnapTests
{
    public class GameOverTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GameOver(int players)
        {
            TestPack pack = new TestPack();
            SnapGame game = new SnapGame(pack, players);

            while(!game.GameOver || game.Turns > 52)
            {
                game.TakeTurn();

                if (game.CheckForSnap()) game.SnapWithWinner(0);
            }

            Assert.Equal(52, game.Players[0].FaceDownPile.Count);
            Assert.Equal(52, game.Turns);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(52)]
        [InlineData(53)]
        [InlineData(104)]
        public void NoWinnersAndFlipHand(int turns)
        {
            Pack pack = new Pack();
            SnapGame game = new SnapGame(pack, 4);

            while (!game.GameOver && game.Turns < turns)
            {
                game.TakeTurn();
                if (game.CheckForSnap()) game.SnapWithWinner(0);
            }

            Assert.False(game.GameOver);
        }
    }
}
