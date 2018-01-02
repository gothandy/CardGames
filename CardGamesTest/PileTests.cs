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

        [Theory]
        [InlineData(1)]
        public void Shuffle(int numberOfTimes)
        {
            TestPack pack = new TestPack();

            pack.Shuffle(numberOfTimes);
        }

        [Theory]
        [InlineData(0, 51, Rank.King, Suit.Heart, Rank.Ace, Suit.Spade)]
        [InlineData(51, 0, Rank.Ace, Suit.Spade, Rank.King, Suit.Heart)]
        [InlineData(1, 50, Rank.King, Suit.Club, Rank.Ace, Suit.Diamond)]
        [InlineData(50, 1, Rank.Ace, Suit.Diamond, Rank.King, Suit.Club)]
        public void Swap(int i1, int i2, Rank r1, Suit s1, Rank r2, Suit s2)
        {
            TestPack pack = new TestPack();

            pack.Swap(i1, i2);

            Assert.Equal(new Card(r1, s1), pack[i1]);
            Assert.Equal(new Card(r2, s2), pack[i2]);
        }
    }
}
