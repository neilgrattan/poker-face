using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerFace
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine(Constants.ERROR_MESSAGE_INVALID_NUMBER_OF_ARGUMENTS);
                Environment.Exit((int)Constants.ExitStatusCode.INVALID_NUMBER_OF_ARGUMENTS);
            }

            var cardHandsFileReader = new CardHandsFileReader(args[0]);
            var pokerFaceMain = new PokerFaceMain(cardHandsFileReader);

            Environment.Exit(pokerFaceMain.EvaluateHands());
        }
    }
}
