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
            Card card = new Card();

            Assert.Equal("Ace of Spades", card.ToString());
        }
    }
}
