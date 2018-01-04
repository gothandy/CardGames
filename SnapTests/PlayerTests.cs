using CardGames;
using Xunit;

namespace SnapTests
{
    public class PlayerTests
    {
        [Fact]
        public void FlipCardSinglePlayer()
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, 2);

            game.Players[0].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Two, Suit.Spade), game.Players[0].FaceUpPile[0]);
        }

        [Fact]
        public void FlipCardTwoPlayers()
        {
            Pack pack = new Pack();

            SnapGame game = new SnapGame(pack, 2);

            game.Players[0].FlipCard();
            game.Players[1].FlipCard();

            Assert.Equal<Card>(new Card(Rank.Ace, Suit.Spade), game.Players[1].FaceUpPile[0]);
        }
    }
}
