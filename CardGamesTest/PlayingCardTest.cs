using PlayingCardLibrary;
using System;
using Xunit;

namespace CardGamesTest
{
    public class PlayingCardTest
    {
        [Fact]
        public void NewCard()
        {
            Card card = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal("Ace of Spades", card.ToString());
        }

        [Fact]
        public void CardEquals()
        {
            Card card1 = new Card(Rank.Ace, Suit.Spade);
            Card card2 = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal<Card>(card1, card2);
        }

        [Fact]
        public void CardHash()
        {
            Card card = new Card(Rank.Ace, Suit.Spade);

            Assert.Equal<int>(1, card.GetHashCode());
        }

        [Fact]
        public void NewPackCount()
        {
            Pack pack = new Pack();

            Assert.Equal(52, pack.Count);
        }

        [Fact]
        public void NewPackOrientationFaceDown()
        {
            Pack pack = new Pack();

            Assert.Equal(Orientation.FaceDown, pack.Orientation);
        }


        [Fact]
        public void NewPackBottomCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), pack[0]);
        }

        [Fact]
        public void NewPackTopCard()
        {
            Pack pack = new Pack();

            Assert.Equal<Card>(new Card(Rank.King, Suit.Heart), pack[51]);
        }

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

        [Fact]
        public void DealCardsToPlayersCardCheck()
        {
            Players players = new Players(2);
            Pack pack = new Pack();

            pack.Deal(players, numberOfCards: 3);

            Assert.Equal(new Card(Rank.Eight, Suit.Heart), players[1].Hand[2]);
        }
    }
}
