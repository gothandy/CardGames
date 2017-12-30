using System;

namespace PlayingCardLibrary
{
    public class SnapPlayer
    {
        public void FlipCard()
        {
            this.FaceDownPile.PlaceTopCard(FaceUpPile);
        }

        public Pile FaceDownPile = new Pile(Orientation.FaceDown);
        public Pile FaceUpPile = new Pile(Orientation.FaceUp);
    }
}