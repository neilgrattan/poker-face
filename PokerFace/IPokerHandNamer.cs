﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerFace.Model;

namespace PokerFace
{
    public interface IPokerHandNamer
    {
        string GetPokerHandNameForCardHand(CardHand cardHand);
    }
}