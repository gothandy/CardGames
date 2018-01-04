using System;

namespace CardGames
{
    public class SnapPlayer
    {
        public Pile FaceDownPile = new Pile(Orientation.FaceDown);
        public Pile FaceUpPile = new Pile(Orientation.FaceUp);

        public void FlipCard()
        {
            if (FaceDownPile.Count == 0)
            {
                FaceUpPile.AddToBottomOf(FaceDownPile);
            }

            FaceDownPile.PlaceTopCardOn(FaceUpPile);
        }

        internal SnapGame game;

        public int Index => game.Players.IndexOf(this);
        public bool IsCurrent => (game.turnTaker.CurrentPlayer == this);
    }
}