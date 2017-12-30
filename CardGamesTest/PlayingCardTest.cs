using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class PlayingCardTest
    {

        [Fact]
        public void NewPile()
        {
            Pile pile = new Pile(Orientation.FaceUp);

            Assert.True(pile.Empty);
        }

        [Fact]
        public void PlacePackTopCardOnPile()
        {
            Pack pack = new Pack();
            Pile pile = new Pile(Orientation.FaceUp);

            pack.PlaceTopCard(pile);

            Assert.Equal(51, pack.Count);
            Assert.Equal(1, pile.Count);
            Assert.Equal(new Card(Rank.King, Suit.Heart), pile[0]);

        }

        [Fact]
        public void NewPlayer()
        {
            Player player = new Player();

            Assert.True(player.Hand.Empty);
        }

        [Fact]
        public void NewPlayers()
        {
            Players players = new Players(2);

            Assert.Equal(2, players.Count);
        }

        [Fact]
        public void DealCardsToPlayersCount()
        {
            Players players = new Players(2);
            Pack pack = new Pack();

            pack.Deal(players, numberOfCards: 3);

            Assert.Equal(3, players[0].Hand.Count);
        }

        [Theory]
        [InlineData(Rank.King, Suit.Heart, 0,0)]
        [InlineData(Rank.Eight, Suit.Heart, 1, 2)]
        public void DealCardsToPlayersCardCheck(Rank rank, Suit suit, int player, int hand)
        {
            Players players = new Players(2);
            Pack pack = new Pack();

            pack.Deal(players, numberOfCards: 3);

            Assert.Equal(new Card(rank, suit), players[player].Hand[hand]);
        }


    }
}
