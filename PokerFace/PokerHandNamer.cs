using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerFace.Model;

namespace PokerFace
{
    public class PokerHandNamer : IPokerHandNamer
    {
        public PokerHandNamer()
        {
        }

        public string GetPokerHandNameForCardHand(CardHand cardHand)
        {
            var cardsGroupedByRank = GroupCardsByRank(cardHand);
            var cardsGroupedBySuit = GroupCardsBySuit(cardHand);

            if (IsHandARoyalFlush(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandRoyalFlush;
            if (IsHandAStraightFlush(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandStraightFlush;
            if (IsHandAFourOfAKind(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandFourOfAKind;
            if (IsHandAFullHouse(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandFullHouse;
            if (IsHandAFlush(cardsGroupedBySuit)) return Constants.PokerHandFlush;
            if (IsHandAStraight(cardsGroupedByRank)) return Constants.PokerHandStraight;
            if (IsHandAThreeOfAKind(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandThreeOfAKind;
            if (IsHandATwoPair(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandTwoPair;
            if (IsHandAOnePair(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandOnePair;
            return Constants.PokerHandHighCard;
        }

        private bool IsHandAOnePair(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandATwoPair(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandAThreeOfAKind(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandAFullHouse(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandAFourOfAKind(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandAStraightFlush(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandARoyalFlush(Dictionary<CardFace, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandAFlush(Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            throw new NotImplementedException();
        }

        private bool IsHandAStraight(Dictionary<CardFace, int> cardsGroupedByRank)
        {
            throw new NotImplementedException();
        }

        private Dictionary<CardSuit, int> GroupCardsBySuit(CardHand cardHand)
        {
            throw new NotImplementedException();
        }

        private Dictionary<CardFace, int> GroupCardsByRank(CardHand cardHand)
        {
            throw new NotImplementedException();
        }
    }
}