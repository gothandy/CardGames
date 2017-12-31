using System;

namespace PlayingCardLibrary
{
    public class SnapGame : Game<SnapPlayer>
    {
        public SnapGame(Pile pile, int playerCount) : base(playerCount)
        {
            this.DealAll(pile, p => p.FaceDownPile);
        }

        public bool CheckForSnap()
        {
            throw new NotImplementedException();
        }
    }
}