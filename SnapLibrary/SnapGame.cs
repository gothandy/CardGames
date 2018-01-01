using System;
using System.Collections.Generic;
using System.Linq;

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
            IEnumerable<Card> topCards = Players.Select(p => p.FaceUpPile.TopCard);
            
            List<Rank> matchingRank = topCards.GroupBy(c => c.Rank)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            return matchingRank.Count == 1;
        }

        public void DoSnap(int player)
        {
            throw new NotImplementedException();
        }
    }
}