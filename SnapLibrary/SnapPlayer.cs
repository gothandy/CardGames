using System;

namespace CardGames
{
    public class SnapPlayer
    {
        public Pile FaceDownPile = new Pile(Orientation.FaceDown);
        public Pile FaceUpPile = new Pile(Orientation.FaceUp);

        public void FlipCard()
        {
            this.FaceDownPile.PlaceTopCard(FaceUpPile);
        }
    }
}