using CardGames;
using Xunit;

namespace SnapTests
{
    public class SnapTests
    {
        [Theory]
        [InlineData(2, 2, true)]
        [InlineData(2, 5, false)]
        [InlineData(4, 2, true)]
        public void CheckForSnap(int players, int turns, bool expected)
        {
            TestPack pack = new TestPack();

            SnapGame game = new SnapGame(pack, players);

            for (int i = 0; i < turns; i++) game.TakeTurn();

            Assert.Equal<bool>(expected, game.CheckForSnap());
        }

        [Theory]
        [InlineData(2, 2, 0, 27)]
        public void SnapWithWinner(int players, int turns, int player, int expectedCount)
        {
            TestPack pack = new TestPack();

            SnapGame game = new SnapGame(pack, players);

            for (int i = 0; i < turns; i++) game.TakeTurn();

            game.SnapWithWinner(player);

            Assert.Equal(expectedCount, game.Players[player].FaceDownPile.Count);
        }

        [Fact]
        public void SnapWithoutWinner()
        {
            TestPack pack = new TestPack();

            SnapGame game = new SnapGame(pack, 2);

            for (int i = 0; i < 2; i++) game.TakeTurn();

            game.SnapWithoutWinner();

            Assert.Equal(2, game.SnapPot.Count);
            Assert.Equal<Orientation>(Orientation.FaceUp, game.SnapPot.Orientation);
        }
    }
}
