﻿using System;

namespace PlayingCardLibrary
{
    public class SnapPlayer : Player
    {
        public void FlipCard()
        {
            this.Hand.PlaceTopCard(FaceUpPile);
        }

        public Pile FaceDownPile = new Pile(Orientation.FaceDown);
        public Pile FaceUpPile = new Pile(Orientation.FaceUp);
    }
}