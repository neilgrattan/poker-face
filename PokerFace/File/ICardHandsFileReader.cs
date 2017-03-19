namespace PokerFace.File
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