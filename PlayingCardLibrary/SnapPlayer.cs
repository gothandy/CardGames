using System;

namespace PlayingCardLibrary
{
    public class SnapPlayer : Player
    {
        public void FlipCard()
        {
            throw new NotImplementedException();
        }

        public Pile FaceUpPile = new Pile(Orientation.FaceUp);
    }
}