using PokerFace.Model;

namespace PokerFace
{
    public interface ICardHandsFileReader
    {
        bool FileExists();

        bool AtEndOfFile();

        CardHand ReadNextCardHand();
    }
}