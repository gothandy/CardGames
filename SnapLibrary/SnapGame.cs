using System;

namespace PlayingCardLibrary
{
    public class SnapGame : Game<SnapPlayer>
    {
        public SnapGame(int playerCount) : base(playerCount)
        {
        }
    }
}