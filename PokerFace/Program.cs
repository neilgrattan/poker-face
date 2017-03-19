using System;
using PokerFace.File;

namespace PokerFace
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(Constants.ErrorMessageInvalidNumberOfArguments);
                Environment.Exit((int)Constants.ExitStatusCode.InvalidNumberOfArguments);
            }

            var cardHandsFileReader = new CardHandsFileReader(args[0]);
            var pokerHandNamer = new PokerHandNamer();
            var pokerFaceMain = new PokerFaceMain(cardHandsFileReader, pokerHandNamer);

            Environment.Exit(pokerFaceMain.EvaluateHands());
        }
    }
}