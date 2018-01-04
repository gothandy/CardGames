using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGames
{
    public class SnapGame : Game<SnapPlayer>
    {
        private bool gameOver = false;
        private int turnCount = 0;

        internal TurnTaker<SnapPlayer> turnTaker;
        public Pile SnapPot = new Pile(Orientation.FaceUp);

        public SnapGame(int playerCount) : base(playerCount)
        {
            Pack pack = new Pack();

            Shuffler shuffler = new Shuffler(new Random());

            shuffler.Shuffle(pack, 52);

            SetupGame(pack);
        }

        public SnapGame(Pile pack, int playerCount) : base(playerCount)
        {
            SetupGame(pack);
        }

        private void SetupGame(Pile pack)
        {
            foreach (SnapPlayer player in Players) player.game = this;

            this.DealAll(pack, p => p.FaceDownPile);

            turnTaker = new TurnTaker<SnapPlayer>(this.Players);
        }

        public void TakeTurn()
        {
            turnTaker.CurrentPlayer.FlipCard();
            turnTaker.NextPlayer();

            turnCount++;
        }

        public int CurrentPlayer => this.Players.IndexOf(turnTaker.CurrentPlayer);

        public bool GameOver => gameOver;

        public int Turns => turnCount;

        public bool IsSnapPossible()
        {
            List<Rank> matchingRank = GetMatchingRank();

            bool value = (matchingRank.Count == 1);

            return value;
        }

        public void SnapWithWinner(int playerIndex)
        {
            Pile winningPile = Players[playerIndex].FaceDownPile;

            PlaceMatchingPilesTo(winningPile);

            gameOver = NoneEmptyHands() == 1;
        }

        private int NoneEmptyHands()
        {
            int count = 0;

            foreach(SnapPlayer player in Players)
            {
                if (player.FaceDownPile.Count > 0 || player.FaceUpPile.Count > 0) count++;
            }

            return count;
        }

        public void SnapWithoutWinner()
        {
            PlaceMatchingPilesTo(SnapPot);
        }

        private void PlaceMatchingPilesTo(Pile winningPile)
        {
            List<Rank> matchingRanks = GetMatchingRank();

            if (matchingRanks.Count == 0)
            {
                // No Snap?
                throw (new NotImplementedException());
            }
            else if (matchingRanks.Count == 1)
            {
                MatchingPilesAddTo(winningPile, matchingRanks);
            }
            else
            {
                // More than one snap Rank, unlikely but possible.
                throw (new NotImplementedException());
            }
        }

        private void MatchingPilesAddTo(Pile winningPile, List<Rank> matchingRanks)
        {
            List<Pile> faceUpPiles = Players.Select(p => p.FaceUpPile).ToList();

            foreach (Pile pile in faceUpPiles)
            {
                if (pile.TopCard != null && pile.TopCard.Rank == matchingRanks[0])
                {
                    pile.AddToBottomOf(winningPile);
                }
            }
        }

        private List<Rank> GetMatchingRank()
        {
            IEnumerable<Card> topCards = Players.Select(p => p.FaceUpPile.TopCard).Where(c => c != null);

            List<Rank> matchingRank = topCards.GroupBy(c => c.Rank)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            return matchingRank;
        }
    }
}