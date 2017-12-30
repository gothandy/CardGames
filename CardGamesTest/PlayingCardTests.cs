using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class PlayingCardTests
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
            Game<Player> game = new Game<Player>(2);

            Assert.Equal(2, game.Players.Count);
        }

        [Fact]
        public void DealCardsToPlayersCount()
        {
            Game<Player> game = new Game<Player>(2);
            Pack pack = new Pack();

            game.Deal(pack, p => p.Hand, numberOfCards: 3);

            Assert.Equal(3, game.Players[0].Hand.Count);
        }

        [Theory]
        [InlineData(Rank.King, Suit.Heart, 0,0)]
        [InlineData(Rank.Eight, Suit.Heart, 1, 2)]
        public void DealCardsToPlayersCardCheck(Rank rank, Suit suit, int player, int hand)
        {
            Game<Player> game = new Game<Player>(2);
            Pack pack = new Pack();

            game.Deal(pack, p => p.Hand, numberOfCards: 3);

            Assert.Equal(new Card(rank, suit), game.Players[player].Hand[hand]);
        }


    }
}
