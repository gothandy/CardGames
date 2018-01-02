using System;

namespace CardGames
{
    public class Shuffler
    {
        private Random random;
        public Shuffler(Random random)
        {
            this.random = random;
        }

        public void Shuffle(Pile pile, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RandomCardSwap(pile);
            }
        }

        private void RandomCardSwap(Pile pile)
        {
            int from = random.Next(pile.Count);
            int to = RandomNotEqualTo(pile.Count, from);

            pile.Swap(from, to);
        }

        private int RandomNotEqualTo(int count, int from)
        {
            while (true)
            {
                int to = random.Next(count);

                if (to != from) return to;
            }
        }
    }
}