using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PokerFace
{
    public class CardHandsFileReader : ICardHandsFileReader
    {
        string filePath;
        StreamReader cardHandsFileStreamReader;

        public CardHandsFileReader(string _filePath)
        {
            filePath = _filePath;
        }

        public bool FileExists()
        {
            return File.Exists(filePath);
        }

        public bool AtEndOfFile()
        {
            return cardHandsFileStreamReader != null && cardHandsFileStreamReader.Peek() < 0;
        }

        public CardHand ReadNextCardHand()
        {
            if (cardHandsFileStreamReader == null)
            {
                OpenCardHandsFile();
            }

            if (!AtEndOfFile())
            {
                return BuildCardHandFromFileLine(cardHandsFileStreamReader.ReadLine());
            }
            else
            {
                return null;
            }
        }

        private CardHand BuildCardHandFromFileLine(string _line)
        {
            // TODO: Implement
            return new CardHand();
        }

        private void OpenCardHandsFile()
        {
            if (cardHandsFileStreamReader != null)
            {
                cardHandsFileStreamReader.Close();
            }
            cardHandsFileStreamReader = new StreamReader(filePath);
        }
    }
}
