using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerFace
{
    public interface ICardHandsFileReader
    {
        bool FileExists();

        bool AtEndOfFile();

        CardHand ReadNextCardHand();
    }
}