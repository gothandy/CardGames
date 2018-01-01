using Xunit;

namespace CardGames
{
    public class TestCardTest
    {
        [Theory]
        [InlineData(0, 0, Rank.King, Suit.Heart)]
        [InlineData(1, 0, Rank.King, Suit.Club)]
        [InlineData(2, 0, Rank.King, Suit.Diamond)]
        [InlineData(3, 0, Rank.King, Suit.Spade)]
        [InlineData(0, 12, Rank.Ace, Suit.Heart)]
        [InlineData(1, 12, Rank.Ace, Suit.Club)]
        [InlineData(2, 12, Rank.Ace, Suit.Diamond)]
        [InlineData(3, 12, Rank.Ace, Suit.Spade)]
        public void NewTestGame(int player, int index, Rank rank, Suit suit)
        {
            TestGame game = new TestGame(4, 13);

            Assert.Equal<Card>(new Card(rank, suit), game.Players[player].Hand[index]);
        }
    }
}
