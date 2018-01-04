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
            StandardConsole consoleStandard = new StandardConsole();
            QuestionAsker consoleHelper = new QuestionAsker(consoleStandard);

            Shuffler shuffler = new Shuffler(new Random());

            Pack pack = new Pack();

            shuffler.Shuffle(pack, 52);

            int noOfPlayers = consoleHelper.AskQuestionLine<int>("How many Players?");

            List<ConsoleKey> playerKeys = Helper.GetPlayerKeys(consoleHelper, noOfPlayers);

            SnapGame game = new SnapGame(pack, noOfPlayers);

            TurnTaker<SnapPlayer> turnTaker = new TurnTaker<SnapPlayer>(game.Players);

            Helper.WriteGame(game);

            Helper.TakeTurn(consoleHelper, game, turnTaker, playerKeys);
        }
    }
}
