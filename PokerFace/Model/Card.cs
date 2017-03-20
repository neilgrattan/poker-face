namespace PokerFace.Model
{
    public enum CardFace
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
        Ace = 14 // Default ace high in mapping
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
        public CardFace Face { get; set; }
        public CardSuit Suit { get; set; }
    }
}