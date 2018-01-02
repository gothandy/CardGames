using CardGames;
using ConsoleLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SnapConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleStandard standard = new ConsoleStandard();
            ConsoleHelper helper = new ConsoleHelper(standard);

            Shuffler shuffler = new Shuffler(new Random());

            Pack pack = new Pack();

            shuffler.Shuffle(pack, 52);

            int noOfPlayers = helper.AskQuestion<int>("How many Players?");

            List<ConsoleKey> playerKeys = Helper.GetPlayerKeys(noOfPlayers);

            SnapGame game = new SnapGame(pack, noOfPlayers);

            TurnTaker<SnapPlayer> turnTaker = new TurnTaker<SnapPlayer>(game.Players);

            Helper.WriteGame(game);

            Helper.TakeTurn(game, turnTaker, playerKeys);
        }
    }
}
