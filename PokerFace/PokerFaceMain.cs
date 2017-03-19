﻿using System;

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
                var cardHand = _cardHandsFileReader.ReadNextCardHand();
            }

            _cardHandsFileReader.CloseFile();
            return (int)Constants.ExitStatusCode.Success;
        }
    }
}