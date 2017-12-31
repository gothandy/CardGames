using System;

namespace PlayingCardLibrary
{
    public class SnapGame : Game<SnapPlayer>
    {
        public SnapGame(Pack pack, int playerCount) : base(playerCount)
        {
            this.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);
        }
    }
}