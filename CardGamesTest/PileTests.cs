using CardGames;
using System;
using Xunit;

namespace CardGames
{
    public class PileTests
    {
        [Fact]
        public void NewPile()
        {
            Pile pile = new Pile(Orientation.FaceUp);

            Assert.True(pile.Empty);
        }

        [Fact]
        public void PlaceTopCard()
        {
            TestPack pack = new TestPack();
            Pile pile = new Pile(Orientation.FaceUp);

            pack.PlaceTopCard(pile);

            Assert.Equal(51, pack.Count);
            Assert.Equal(1, pile.Count);
            Assert.Equal(new Card(Rank.King, Suit.Heart), pile[0]);
        }

        [Fact]
        public void AddToBottomOtherHandEmpty()
        {
            TestGame game = new TestGame(4, 13);

            game.Players[0].Hand.AddToBottom(game.Players[1].Hand);

            Assert.True(game.Players[1].Hand.Empty);
        }

        [Theory]
        [InlineData(0, Rank.King, Suit.Club)]
        [InlineData(12, Rank.Ace, Suit.Club)]
        [InlineData(13, Rank.King, Suit.Heart)]
        [InlineData(25, Rank.Ace, Suit.Heart)]
        public void AddToBottom(int index, Rank rank, Suit suit)
        {
            TestGame game = new TestGame(4, 13);

            game.Players[0].Hand.AddToBottom(game.Players[1].Hand);

            Assert.Equal<Card>(new Card(rank, suit), game.Players[0].Hand[index]);
        }

        [Fact]
        public void FlipOrientation()
        {
            TestGame game = new TestGame(4, 13);

            game.Players[0].Hand.Flip();

            Assert.Equal<Orientation>(Orientation.FaceUp, game.Players[0].Hand.Orientation);
        }

        [Theory]
        [InlineData(0, Rank.Ace, Suit.Heart)]
        [InlineData(12, Rank.King, Suit.Heart)]
        public void Flip(int index, Rank rank, Suit suit)
        {
            TestGame game = new TestGame(4, 13);

            game.Players[0].Hand.Flip();

            Assert.Equal<Card>(new Card(rank, suit), game.Players[0].Hand[index]);
        }

        [Theory]
        [InlineData(0, Rank.King, Suit.Club)]
        [InlineData(12, Rank.Ace, Suit.Club)]
        [InlineData(13, Rank.King, Suit.Heart)]
        [InlineData(25, Rank.Ace, Suit.Heart)]
        public void FlipAndAddToBottom(int index, Rank rank, Suit suit)
        {
            TestGame game = new TestGame(4, 13);

            game.Players[1].Hand.Flip();

            game.Players[0].Hand.AddToBottom(game.Players[1].Hand);

            Assert.Equal<Card>(new Card(rank, suit), game.Players[0].Hand[index]);
        }
    }
}
