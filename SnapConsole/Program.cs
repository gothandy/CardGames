using CardGames;
using ConsoleLibrary;
using System;
using System.Collections.Generic;

namespace SnapConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Pack pack = new Pack();

            Shuffler shuffler = new Shuffler(new Random());

            shuffler.Shuffle(pack, 52);

            SnapGame game = new SnapGame(pack, 2);

            Write(game);

            while (!game.GameOver)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch(key)
                {
                    case ConsoleKey.Spacebar:
                        game.TakeTurn();
                        Write(game);
                        break;

                    case ConsoleKey.Q:
                        Snap(game, 0);
                        break;

                    case ConsoleKey.P:
                        Snap(game, 1);
                        break;
                }
            }

            Console.WriteLine("We have a winner!");
        }

        private static void Write(SnapGame game)
        {
            Console.Clear();

            WriteTurnAndCardCounts(game);

            Console.WriteLine();

            WriteTopCards(game);

            Console.WriteLine();
        }

        private static void WriteTurnAndCardCounts(SnapGame game)
        {
            Console.WriteLine("Turn {0}", game.Turns);

            foreach (SnapPlayer player in game.Players)
            {
                int index = game.Players.IndexOf(player);

                Console.WriteLine("P{0} Face Up {1}, Face Down {2}", index, player.FaceUpPile.Count, player.FaceDownPile.Count);
            }
        }

        private static void WriteTopCards(SnapGame game)
        {
            foreach (SnapPlayer player in game.Players)
            {
                int index = game.Players.IndexOf(player);
                string currentIndicator = String.Empty;
                string topCard = "{no cards}";

                if (player.FaceUpPile.Count != 0) topCard = player.FaceUpPile.TopCard.ToString();

                if (game.CurrentPlayer == index) currentIndicator = " <<";

                Console.WriteLine("P{0} {1}{2}", index, topCard, currentIndicator);
            }
        }

        private static void Snap(SnapGame game, int playerIndex)
        {
            if (game.IsSnapPossible())
            {
                game.SnapWithWinner(playerIndex);
                Write(game);
                Console.WriteLine("Player {0} SNAP!!", playerIndex);
            }
            else
            {
                Console.WriteLine("Player {0} DOH!!", playerIndex);
            }
        }
    }
}
