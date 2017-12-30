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
        public void NewGame(int player)
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, numberOfCards: 26);

            Assert.Equal(26, snapPlayers[player].Hand.Count);

        }

        [Fact]
        public void FlipCard()
        {
            Pack pack = new Pack();

            SnapPlayers snapPlayers = new SnapPlayers(2);

            snapPlayers.Deal(pack, numberOfCards: 26);

            snapPlayers[0].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), snapPlayers[0].FaceUpPile[0]);
        }
    }
}
