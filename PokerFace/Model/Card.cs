namespace PokerFace.Model
{
    public enum CardRank
    {
        AceLow = 1,
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Joker = 11,
        Queen = 12,
        King = 13,
        AceHigh = 14
    }

    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public class Card
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
    }
}