using CardGames;
using System;
using System.ComponentModel;

namespace SnapConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            Pack pack = new Pack();

            pack.Shuffle(52);

            WritePack(pack);

            int howManyPlayers = AskQuestion<int>("How many Players?");

            SnapGame game = new SnapGame(pack, howManyPlayers);


        }

        private static void WritePack(Pack pack)
        {
            Console.Clear();
            foreach (Card card in pack)
            {
                Console.WriteLine(card);
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        private static T AskQuestion<T>(string question) where T : struct
        {
            

            while(true)
            {
                Console.WriteLine(question);

                string possibleAnswer = Console.ReadLine();

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null && converter.IsValid(possibleAnswer))
                {
                    return (T)converter.ConvertFromString(possibleAnswer);
                }

                Console.Clear();
            }
        }
    }
}
