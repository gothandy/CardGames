using System;

namespace PlayingCardLibrary
{
    public class SnapPlayers : Players<SnapPlayer>
    {
        public SnapPlayers(int playerCount) : base(playerCount)
        {
        }
    }
}