using System;

namespace PlayingCardLibrary
{
    public class SnapGame : Game<SnapPlayer>
    {
        public SnapGame(Pack pack, int playerCount) : base(playerCount)
        {
            this.DealAll(pack, p => p.FaceDownPile);
        }
    }
}