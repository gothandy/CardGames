using CardGames;
using Xunit;

namespace SnapTests
{
    public class NewGameTests
    {

        [Theory]
        [InlineData(2, 0, 26)]
        [InlineData(2, 1, 26)]
        [InlineData(3, 0, 18)]
        [InlineData(3, 2, 17)]
        [InlineData(4, 0, 13)]
        public void MultiplePlayers(int playerCount, int playerToAssert, int expectedCardCount)
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, playerCount);

            Assert.Equal(expectedCardCount, game.Players[playerToAssert].FaceDownPile.Count);
        }

        [Theory]
        [InlineData(Rank.King, Suit.Heart, 0, 0)]
        [InlineData(Rank.Queen, Suit.Heart, 1, 0)]
        [InlineData(Rank.Two, Suit.Spade, 0, 25)]
        [InlineData(Rank.Ace, Suit.Spade, 1, 25)]
        public void NewGameAssertCardEqual(Rank rank, Suit suit, int player, int index)
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, playerCount: 2);

            Assert.Equal<Card>(new Card(rank, suit), game.Players[player].FaceDownPile[index]);
        }
    }
}
