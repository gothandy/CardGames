using CardGames;
using System;
using Xunit;

namespace CardGamesTest
{
    public class ShufflerTest
    {
        [Theory]
        [InlineDataAttribute(0, 37, Rank.Ten, Suit.Diamond)]
        [InlineDataAttribute(0, 42, Rank.Jack, Suit.Club)]
        [InlineDataAttribute(1, 37, Rank.Jack, Suit.Club)]
        [InlineDataAttribute(1, 42, Rank.Ten, Suit.Diamond)]
        public void Shuffle(int count, int index, Rank rank, Suit suit)
        {
            TestPack pack = new TestPack();

            Random random = new Random(0);

            Shuffler shuffler = new Shuffler(random);

            shuffler.Shuffle(pack, count);

            Assert.Equal(new Card(rank, suit), pack[index]);
        }
    }
}
