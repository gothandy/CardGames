using Xunit;

namespace CardGames
{
    public class TestPackTest
    {
        [Theory]
        [InlineData(0, Rank.Ace, Suit.Spade)]
        [InlineData(1, Rank.Ace, Suit.Diamond)]
        [InlineData(2, Rank.Ace, Suit.Club)]
        [InlineData(3, Rank.Ace, Suit.Heart)]
        [InlineData(48, Rank.King, Suit.Spade)]
        [InlineData(49, Rank.King, Suit.Diamond)]
        [InlineData(50, Rank.King, Suit.Club)]
        [InlineData(51, Rank.King, Suit.Heart)]
        public void NewTestPack(int index, Rank rank, Suit suit)
        {
            TestPack pack = new TestPack();

            Assert.Equal<Card>(new Card(rank, suit), pack[index]);
        }       
    }
}
