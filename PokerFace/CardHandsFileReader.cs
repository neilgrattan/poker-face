using System.IO;
using PokerFace.Mappings;
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
            return _cardHandsFileStreamReader.Peek() < 0;
        }

        public CardHand ReadNextCardHand()
        {
            if (!AtEndOfFile())
            {
                return BuildCardHandFromFileLine(_cardHandsFileStreamReader.ReadLine());
            }

            return null;
        }

        private static CardHand BuildCardHandFromFileLine(string line)
        {
            return MapStringArrayToCardHand.Map(line.Split(' '));
        }

        public void OpenFile()
        {
            CloseFile();
            _cardHandsFileStreamReader = new StreamReader(_filePath);
        }

        public void CloseFile()
        {
            _cardHandsFileStreamReader?.Close();
        }
    }
}