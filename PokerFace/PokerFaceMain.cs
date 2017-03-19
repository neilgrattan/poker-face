using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerFace
{
    public class PokerFaceMain
    {
        private ICardHandsFileReader cardHandsFileReader;

        public PokerFaceMain(ICardHandsFileReader _cardHandsFileReader)
        {
            cardHandsFileReader = _cardHandsFileReader;
        }

        public int EvaluateHands()
        {
            if (!cardHandsFileReader.FileExists())
            {
                Console.WriteLine(Constants.ERROR_MESSAGE_INPUT_FILE_NOT_FOUND);
                return (int)Constants.ExitStatusCode.INPUT_FILE_NOT_FOUND;
            }

            while (!cardHandsFileReader.AtEndOfFile())
            {
                var cardHand = cardHandsFileReader.ReadNextCardHand();
            }

            return (int)Constants.ExitStatusCode.SUCCESS;
        }
    }
}