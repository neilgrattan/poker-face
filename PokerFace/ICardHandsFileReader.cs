using PokerFace.Model;

namespace PokerFace
{
    public interface ICardHandsFileReader
    {
        bool FileExists();

        bool AtEndOfFile();

        string ReadNextCardHandLine();

        void OpenFile();

        void CloseFile();
    }
}