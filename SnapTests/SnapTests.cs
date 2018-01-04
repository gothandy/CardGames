using CardGames;
using Xunit;

namespace SnapTests
{
    public class SnapTests
    {
        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(2, 5, false)]
        public void CheckForSnap(int players, int turns, bool expected)
        {
            SnapGame game = SetUpGame(players, turns);

            Assert.Equal<bool>(expected, game.CheckForSnap());
        }

        [Theory]
        [InlineData(2, 2, 0, 27)]
        public void DoSnap(int players, int turns, int player, int expectedCount)
        {
            SnapGame game = SetUpGame(players, turns);

            game.DoSnap(player);

            Assert.Equal(expectedCount, game.Players[player].FaceDownPile.Count);
        }

        private static SnapGame SetUpGame(int players, int turns)
        {
            TestPack pack = new TestPack();

            SnapGame game = new SnapGame(pack, players);

            TurnTaker<SnapPlayer> turnTaker = new TurnTaker<SnapPlayer>(game.Players);

            for (int i = 0; i < turns; i++)
            {
                turnTaker.CurrentPlayer.FlipCard();
                turnTaker.NextPlayer();
            }

            return game;
        }
    }
}
