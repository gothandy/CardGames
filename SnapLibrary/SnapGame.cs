using System;

namespace PlayingCardLibrary
{
    public class SnapGame : Game<SnapPlayer>
    {
        public SnapGame(int playerCount) : base(playerCount)
        {
            Pack pack = new Pack();

            this.Deal(pack, p => p.FaceDownPile, numberOfCards: 26);
        }
    }
}