﻿using System.IO;

namespace PokerFace.File
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
            return System.IO.File.Exists(_filePath);
        }

        public bool AtEndOfFile()
        {
            return _cardHandsFileStreamReader.Peek() < 0;
        }

        public string ReadNextCardHandLine()
        {
            if (!AtEndOfFile())
            {
                return _cardHandsFileStreamReader.ReadLine();
            }

            return null;
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