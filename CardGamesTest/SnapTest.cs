using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class SnapTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void NewGameCount(int player)
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);

            Assert.Equal(26, snapPlayers[player].FaceDownPile.Count);

        }

        [Theory]
        [InlineData(Rank.King, Suit.Heart, 0, 0)]
        [InlineData(Rank.Queen, Suit.Heart, 1, 0)]
        [InlineData(Rank.Two, Suit.Spade, 0, 25)]
        [InlineData(Rank.Ace, Suit.Spade, 1, 25)]
        public void NewGameAssertCardEqual(Rank rank, Suit suit, int player, int index)
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);

            Assert.Equal<Card>(new Card(rank, suit), snapPlayers[player].FaceDownPile[index]);

        }

        [Fact]
        public void FlipCard()
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, numberOfCards: 26);

            snapPlayers[0].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Two, Suit.Spade), snapPlayers[0].FaceUpPile[0]);
        }

        [Fact]
        public void FlipCardBothPlayers()
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, numberOfCards: 26);

            snapPlayers[0].FlipCard();
            snapPlayers[1].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), snapPlayers[1].FaceUpPile[0]);
        }
    }
}
