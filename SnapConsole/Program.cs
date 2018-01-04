using CardGames;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SnapConsole
{
    class Program
    {
        private static DateTime snapTimer = DateTime.MinValue;

        static void Main(string[] args)
        {
            int players = GetNumberOfPlayers();

            SnapGame game = new SnapGame(players);

            List<ConsoleKey> snapKeys = new List<ConsoleKey>() { ConsoleKey.Q, ConsoleKey.P, ConsoleKey.P };
            List<ConsoleKey> turnKeys = new List<ConsoleKey>() { ConsoleKey.A, ConsoleKey.L, ConsoleKey.B };

            Write(game);

            while (!game.GameOver)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                int snapIndex = snapKeys.IndexOf(key);
                int turnIndex = turnKeys.IndexOf(key);

                if (snapIndex != -1) Snap(game, snapIndex);
                if (turnIndex != -1) Turn(game, turnIndex);
            }

            Console.WriteLine("We have a winner!");
            Thread.Sleep(5000);
        }

        private static int GetNumberOfPlayers()
        {
            Console.WriteLine("Number of Players? 2/3");
            int players = (Console.ReadKey(true).Key == ConsoleKey.D2 ? 2 : 3);
            return players;
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
                Console.WriteLine("P{0} Face Up {1}, Face Down {2}, Total {3}",
                    player.Index + 1,
                    player.FaceUpPile.Count,
                    player.FaceDownPile.Count,
                    player.FaceUpPile.Count + player.FaceDownPile.Count);
            }
        }

        private static void WriteTopCards(SnapGame game)
        {
            foreach (SnapPlayer player in game.Players)
            {
                string currentIndicator = player.IsCurrent ? " <<" : String.Empty;
                string topCard = player.FaceUpPile.Empty ? "{no cards}" : player.FaceUpPile.TopCard.ToString();

                Console.WriteLine("P{0} {1}{2}", player.Index + 1, topCard, currentIndicator);
            }
        }

        private static void Snap(SnapGame game, int playerIndex)
        {
            if (game.IsSnapPossible())
            {
                SnapWinner(game, playerIndex);
            }
            else
            {
                NotSnap(playerIndex);
            }
        }

        private static void NotSnap(int playerIndex)
        {
            Console.Write("Player {0} DOH!!", playerIndex + 1);
            if (snapTimer != DateTime.MinValue) Console.Write(" {0:0} milliseconds too late!", DateTime.Now.Subtract(snapTimer).TotalMilliseconds);
            Console.WriteLine();
        }

        private static void SnapWinner(SnapGame game, int playerIndex)
        {
            game.SnapWithWinner(playerIndex);
            Write(game);
            Console.WriteLine("Player {0} SNAP!!", playerIndex + 1);
            snapTimer = DateTime.Now;
        }

        private static void Turn(SnapGame game, int turnIndex)
        {
            if (game.CurrentPlayer == turnIndex)
            {
                game.TakeTurn();
                Write(game);
                snapTimer = DateTime.MinValue;
            }
            else
            {
                Console.WriteLine("Player {0} DOH!! Not your turn!", turnIndex + 1);
            }
        }
    }
}
