using CardGamesLibrary;
using Xunit;

namespace CardGamesTest
{
    public class GameTests
    {
        [Theory]
        [InlineData(2, 0, 0)]
        [InlineData(2, 1, 1)]
        [InlineData(2, 2, 0)]
        [InlineData(2, 3, 1)]
        [InlineData(10, 10, 0)]
        public void GetTurnTaker(int numberOfPlayers, int numberOfTurns, int expectedPlayer)
        {
            TestGame game = new TestGame(numberOfPlayers, 3);

            TurnTaker<TestPlayer> turnTaker = new TurnTaker<TestPlayer>(game.Players);

            for (int i = 0; i < numberOfTurns; i++)
            {
                turnTaker.NextPlayer();
            }

            Assert.Equal<int>(expectedPlayer, game.Players.IndexOf(turnTaker.CurrentPlayer));

        }
    }
}
