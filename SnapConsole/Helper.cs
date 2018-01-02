﻿using CardGames;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SnapConsole
{
    internal static class Helper
    {
        internal static void WritePack(Pack pack)
        {
            Console.Clear();
            foreach (Card card in pack)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey(true);
            Console.Clear();
        }



        internal static List<ConsoleKey> GetPlayerKeys(int noOfPlayers)
        {
            List<ConsoleKey> keys = new List<ConsoleKey>();

            Console.Clear();

            foreach(int index in Enumerable.Range(1, noOfPlayers))
            {
                Console.Write("Player {0} press your snap key now: ", index);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.WriteLine(keyInfo.KeyChar.ToString().ToUpper());

                keys.Add(keyInfo.Key);
            }

            return keys;
        }

        internal static void WriteGame(SnapGame game)
        {
            Console.Clear();
            foreach(SnapPlayer player in game.Players)
            {
                WritePlayer(player, game.Players.IndexOf(player));
            }
            
        }

        private static void WritePlayer(SnapPlayer player, int index)
        {
            int playerNumber = index + 1;
            string card = "No Card";

            if (player.FaceUpPile.Count != 0) card = player.FaceUpPile.TopCard.ToString();

            Console.WriteLine("Player {0} {1}", playerNumber, card);

        }

        internal static void TakeTurn(SnapGame game, TurnTaker<SnapPlayer> turnTaker, List<ConsoleKey> playerKeys)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Spacebar)
            {

            }

            
        }
    }
}
