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
            return cardsGroupedBySuit.Values.Max() == 1;
        }

        private bool IsHandAStraight(Dictionary<CardFace, int> cardsGroupedByRank)
        {
            // Condition 1: Ensure each card rank is unique
            if (cardsGroupedByRank.Values.Max() == 1)
            {
                var highestRankedCard = cardsGroupedByRank.Keys.Max();
                var handContainsAce = highestRankedCard == CardFace.Ace;
                var lowestRankedCard = cardsGroupedByRank.Keys.Min();

                // Condition 2: Make sure all the cards are grouped together
                if (highestRankedCard - lowestRankedCard == (Constants.NumberOfCardsInHand - 1))
                {
                    return true;
                }

                // If the hand contained an ace, try again with aces low.
                if (handContainsAce)
                {
                    lowestRankedCard = CardFace.AceLow;
                    highestRankedCard = cardsGroupedByRank.Keys
                        .Where(cardRank => cardRank != CardFace.Ace)
                        .Max();

                    if (highestRankedCard - lowestRankedCard == (Constants.NumberOfCardsInHand - 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private Dictionary<CardSuit, int> GroupCardsBySuit(CardHand cardHand)
        {
            return cardHand.Cards
                .GroupBy(card => card.Suit)
                .Select(cardGroup => new
                {
                    Key = cardGroup.Key,
                    Val = cardGroup.Count()
                })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Val);
        }

        private Dictionary<CardFace, int> GroupCardsByRank(CardHand cardHand)
        {
            return cardHand.Cards
                .GroupBy(card => card.Face)
                .Select(cardGroup => new
                {
                    Key = cardGroup.Key,
                    Val = cardGroup.Count()
                })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Val);
        }
    }
}