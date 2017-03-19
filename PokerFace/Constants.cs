using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerFace
{
    public static class Constants
    {
        public const string ERROR_MESSAGE_INVALID_NUMBER_OF_ARGUMENTS = "Invalid number of arguments.";
        public const string ERROR_MESSAGE_INPUT_FILE_NOT_FOUND = "Specified file does not exist";

        public enum ExitStatusCode
        {
            SUCCESS = 0,
            INVALID_NUMBER_OF_ARGUMENTS,
            INPUT_FILE_NOT_FOUND
        }
    }
}