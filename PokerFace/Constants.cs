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
    }
}