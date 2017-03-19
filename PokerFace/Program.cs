using System;

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
            var pokerFaceMain = new PokerFaceMain(cardHandsFileReader);

            Environment.Exit(pokerFaceMain.EvaluateHands());
        }
    }
}