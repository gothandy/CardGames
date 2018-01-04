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

        [Theory]
        [InlineData(0, 0, Rank.King, Suit.Heart)]
        [InlineData(1, 0, Rank.King, Suit.Club)]
        [InlineData(2, 0, Rank.King, Suit.Diamond)]
        [InlineData(3, 0, Rank.King, Suit.Spade)]
        [InlineData(0, 12, Rank.Ace, Suit.Heart)]
        [InlineData(1, 12, Rank.Ace, Suit.Club)]
        [InlineData(2, 12, Rank.Ace, Suit.Diamond)]
        [InlineData(3, 12, Rank.Ace, Suit.Spade)]
        public void FourPlayerGame(int player, int index, Rank rank, Suit suit)
        {
            TestGame game = new TestGame(4, 13);

            Assert.Equal<Card>(new Card(rank, suit), game.Players[player].Hand[index]);
        }
    }
}
