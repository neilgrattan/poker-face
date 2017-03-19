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

        public const int NumberOfCardsInHand = 5;

        public const string PokerHandHighCard = "High card";
        public const string PokerHandOnePair = "One pair";
        public const string PokerHandTwoPair = "Two pair";
        public const string PokerHandThreeOfAKind = "Three of a kind";
        public const string PokerHandStraight = "Straight";
        public const string PokerHandFlush = "Flush";
        public const string PokerHandFullHouse = "Full house";
        public const string PokerHandFourOfAKind = "Four of a kind";
        public const string PokerHandStraightFlush = "Straight flush";
        public const string PokerHandRoyalFlush = "Royal flush";
    }
}