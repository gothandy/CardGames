using Xunit;

namespace CardGames
{
    public class GameTests
    {

        [Fact]
        public void DealCardsToPlayersCount()
        {
            TestGame game = new TestGame(2, 3);

            Assert.Equal(3, game.Players[0].Hand.Count);
        }

        [Theory]
        [InlineData(0, 0, Rank.King, Suit.Heart)]
        [InlineData(0, 1, Rank.King, Suit.Diamond)]
        [InlineData(0, 2, Rank.Queen, Suit.Heart)]
        [InlineData(1, 0, Rank.King, Suit.Club)]
        [InlineData(1, 1, Rank.King, Suit.Spade)]
        [InlineData(1, 2, Rank.Queen, Suit.Club)]
        public void DealCardsToPlayersCardCheck(int player, int hand, Rank rank, Suit suit)
        {
            TestGame game = new TestGame(2, 3);

            Assert.Equal(new Card(rank, suit), game.Players[player].Hand[hand]);
        }
    }
}
