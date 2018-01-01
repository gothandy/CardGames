using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    public class SnapGame : Game<SnapPlayer>
    {
        public SnapGame(Pile pile, int playerCount) : base(playerCount)
        {
            this.DealAll(pile, p => p.FaceDownPile);
        }

        public bool CheckForSnap()
        {
            List<Rank> matchingRank = GetMatchingRank();

            return matchingRank.Count == 1;
        }

        public void DoSnap(int player)
        {
            List<Rank> matchingRanks = GetMatchingRank();

            if (matchingRanks.Count == 0)
            {
                // No Snap?
                throw (new NotImplementedException());
            }
            if (matchingRanks.Count == 1)
            {
                List<Pile> faceUpPiles = Players.Select(p => p.FaceUpPile).ToList();

                foreach(Pile pile in faceUpPiles)
                {
                    if (pile.TopCard.Rank == matchingRanks[0])
                    {
                        Players[player].FaceDownPile.AddToBottom(pile);
                    }
                }
            }
            else
            {
                // More than one snap Rank, unlikely but possible.
                throw (new NotImplementedException());
            }
        }
        
        private List<Rank> GetMatchingRank()
        {
            IEnumerable<Card> topCards = Players.Select(p => p.FaceUpPile.TopCard);

            List<Rank> matchingRank = topCards.GroupBy(c => c.Rank)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            return matchingRank;
        }


    }
}