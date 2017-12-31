using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class SnapTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void NewGameCount(int player)
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, 2);

            Assert.Equal(26, game.Players[player].FaceDownPile.Count);
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

        [Fact]
        public void FlipCard()
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, 2);

            game.Players[0].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Two, Suit.Spade), game.Players[0].FaceUpPile[0]);
        }

        [Fact]
        public void FlipCardBothPlayers()
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, 2);

            game.Players[0].FlipCard();
            game.Players[1].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), game.Players[1].FaceUpPile[0]);
        }

        [Theory]
        [InlineData(3, 0, 18)]
        [InlineData(3, 2, 17)]
        [InlineData(4, 0, 13)]
        public void MultiplePlayers(int playerCount, int playerToAssert, int expectedCardCount)
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, playerCount);

            Assert.Equal(expectedCardCount, game.Players[playerToAssert].FaceDownPile.Count);
        }
    }
}
