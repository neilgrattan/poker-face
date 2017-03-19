using System;
using System.Text;
using PokerFace.File;
using PokerFace.Mappings;

namespace PokerFace
{
    public class PokerFaceMain
    {
        private readonly ICardHandsFileReader _cardHandsFileReader;
        private readonly IPokerHandNamer _pokerHandNamer;

        public PokerFaceMain(ICardHandsFileReader cardHandsFileReader, IPokerHandNamer pokerHandNamer)
        {
            _cardHandsFileReader = cardHandsFileReader;
            _pokerHandNamer = pokerHandNamer;
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
                    var pokerHandName = _pokerHandNamer.Name(cardHand);
                    Console.WriteLine($"{cardHandString} => {pokerHandName}");
                }
                else
                {
                    Console.WriteLine($"Error: Could not construct valid card hand from line: {cardHandString}");
                }
            }

            _cardHandsFileReader.CloseFile();
            return (int)Constants.ExitStatusCode.Success;
        }
    }
}