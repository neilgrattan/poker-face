using System.IO;
using PokerFace.Model;

namespace PokerFace
{
    public class CardHandsFileReader : ICardHandsFileReader
    {
        private readonly string _filePath;
        private StreamReader _cardHandsFileStreamReader;

        public CardHandsFileReader(string filePath)
        {
            _filePath = filePath;
        }

        public bool FileExists()
        {
            return File.Exists(_filePath);
        }

        public bool AtEndOfFile()
        {
            return _cardHandsFileStreamReader != null && _cardHandsFileStreamReader.Peek() < 0;
        }

        public CardHand ReadNextCardHand()
        {
            if (_cardHandsFileStreamReader == null)
            {
                OpenCardHandsFile();
            }

            if (!AtEndOfFile())
            {
                return BuildCardHandFromFileLine(_cardHandsFileStreamReader.ReadLine());
            }

            return null;
        }

        private static CardHand BuildCardHandFromFileLine(string line)
        {
            // TODO: Implement
            return new CardHand();
        }

        private void OpenCardHandsFile()
        {
            _cardHandsFileStreamReader?.Close();
            _cardHandsFileStreamReader = new StreamReader(_filePath);
        }
    }
}