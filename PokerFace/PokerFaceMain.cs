using System;
using PokerFace.Mappings;

namespace PokerFace
{
    public class PokerFaceMain
    {
        private readonly ICardHandsFileReader _cardHandsFileReader;

        public PokerFaceMain(ICardHandsFileReader cardHandsFileReader)
        {
            _cardHandsFileReader = cardHandsFileReader;
        }

        public int EvaluateHands()
        {
            if (!_cardHandsFileReader.FileExists())
            {
                Console.WriteLine(Constants.ErrorMessageInputFileNotFound);
                return (int)Constants.ExitStatusCode.InputFileNotFound;
            }

            _cardHandsFileReader.OpenFile();
            while (!_cardHandsFileReader.AtEndOfFile())
            {
                var cardHandString = _cardHandsFileReader.ReadNextCardHandLine();
                var cardHand = MapStringToCardHand.Map(cardHandString);

                if (cardHand != null)
                {
                }
            }

            _cardHandsFileReader.CloseFile();
            return (int)Constants.ExitStatusCode.Success;
        }
    }
}