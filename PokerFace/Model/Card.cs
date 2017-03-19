namespace PokerFace.Model
{
    public enum CardFace
    {
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
        Ace = 14
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