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

            Snap snap = new Snap(2);

            snap.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);

            Assert.Equal(26, snap.Players[player].FaceDownPile.Count);

        }

        [Theory]
        [InlineData(Rank.King, Suit.Heart, 0, 0)]
        [InlineData(Rank.Queen, Suit.Heart, 1, 0)]
        [InlineData(Rank.Two, Suit.Spade, 0, 25)]
        [InlineData(Rank.Ace, Suit.Spade, 1, 25)]
        public void NewGameAssertCardEqual(Rank rank, Suit suit, int player, int index)
        {
            Pack pack = new Pack();

            Snap snap = new Snap(playerCount: 2);

            snap.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);

            Assert.Equal<Card>(new Card(rank, suit), snap.Players[player].FaceDownPile[index]);

        }

        [Fact]
        public void FlipCard()
        {
            Pack pack = new Pack();

            Snap snap = new Snap(2);

            snap.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);

            snap.Players[0].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Two, Suit.Spade), snap.Players[0].FaceUpPile[0]);
        }

        [Fact]
        public void FlipCardBothPlayers()
        {
            Pack pack = new Pack();

            Snap snap = new Snap(2);

            snap.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);

            snap.Players[0].FlipCard();
            snap.Players[1].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), snap.Players[1].FaceUpPile[0]);
        }
    }
}
