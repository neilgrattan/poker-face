namespace PokerFace
{
    public static class Constants
    {
        // Console application constants and enums
        public const string ErrorMessageInvalidNumberOfArguments = "Invalid number of arguments.";

        public const string ErrorMessageInputFileNotFound = "Specified file does not exist";

        public enum ExitStatusCode
        {
            Success = 0,
            InvalidNumberOfArguments,
            InputFileNotFound
        }

        // Application logic constants
        public const int NumberOfCardsInHand = 5;

        public const string PokerHandNameHighCard = "High card";
        public const string PokerHandNameOnePair = "One pair";
        public const string PokerHandNameTwoPair = "Two pair";
        public const string PokerHandNameThreeOfAKind = "Three of a kind";
        public const string PokerHandNameStraight = "Straight";
        public const string PokerHandNameFlush = "Flush";
        public const string PokerHandNameFullHouse = "Full house";
        public const string PokerHandNameFourOfAKind = "Four of a kind";
        public const string PokerHandNameStraightFlush = "Straight flush";
        public const string PokerHandNameRoyalFlush = "Royal flush";
    }
}