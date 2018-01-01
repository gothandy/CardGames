using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class PlayingCardTests
    {

        [Fact]
        public void NewPlayer()
        {
            TestPlayer player = new TestPlayer();

            Assert.True(player.Hand.Empty);
        }

        [Fact]
        public void NewPlayers()
        {
            TestGame game = new TestGame(2);

            Assert.Equal(2, game.Players.Count);
        }

        [Fact]
        public void DealCardsToPlayersCount()
        {
            TestGame game = new TestGame(2);

            Assert.Equal(3, game.Players[0].Hand.Count);
        }

        [Theory]
        [InlineData(Rank.King, Suit.Heart, 0,0)]
        [InlineData(Rank.Eight, Suit.Heart, 1, 2)]
        public void DealCardsToPlayersCardCheck(Rank rank, Suit suit, int player, int hand)
        {
            TestGame game = new TestGame(2);

            Assert.Equal(new Card(rank, suit), game.Players[player].Hand[hand]);
        }


    }
}
