using CardGames;
using Xunit;

namespace SnapTests
{
    public class SnapTests
    {
        [Theory]
        [InlineData(2, 0, false)]
        [InlineData(2, 1, false)]
        [InlineData(2, 2, true)]
        [InlineData(2, 5, false)]
        [InlineData(4, 2, true)]
        [InlineData(4, 3, true)]
        [InlineData(4, 4, true)]
        public void CheckForSnap(int players, int turns, bool expected)
        {
            TestPack pack = new TestPack();

            SnapGame game = new SnapGame(pack, players);

            for (int i = 0; i < turns; i++) game.TakeTurn();

            Assert.Equal<bool>(expected, game.IsSnapPossible());
        }

        [Theory]
        [InlineData(2, 2, 0, 27)]
        [InlineData(4, 2, 0, 14)]
        [InlineData(4, 2, 2, 15)]
        [InlineData(4, 3, 3, 16)]
        [InlineData(4, 5, 3, 15)]
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

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(1, 0, false)]
        [InlineData(2, 0, true)]
        [InlineData(3, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, 1, true)]
        [InlineData(2, 1, false)]
        [InlineData(3, 1, true)]
        public void PlayerIsCurrent(int turns, int player, bool current)
        {
            TestPack pack = new TestPack();
            SnapGame game = new SnapGame(pack, 2);

            for (int i = 0; i < turns; i++) game.TakeTurn();

            Assert.Equal<bool>(current, game.Players[player].IsCurrent);
        }

        [Fact]
        public void PlayerIndex()
        {
            TestPack pack = new TestPack();
            SnapGame game = new SnapGame(pack, 4);

            Assert.Equal(0, game.Players[0].Index);
            Assert.Equal(1, game.Players[1].Index);
            Assert.Equal(2, game.Players[2].Index);
            Assert.Equal(3, game.Players[3].Index);
        }
    }
}
