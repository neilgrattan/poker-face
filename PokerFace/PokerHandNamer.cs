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

            if (IsHandARoyalFlush(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandNameRoyalFlush;
            if (IsHandAStraightFlush(cardsGroupedByRank, cardsGroupedBySuit)) return Constants.PokerHandNameStraightFlush;
            if (IsHandAFourOfAKind(cardsGroupedByRank)) return Constants.PokerHandNameFourOfAKind;
            if (IsHandAFullHouse(cardsGroupedByRank)) return Constants.PokerHandNameFullHouse;
            if (IsHandAFlush(cardsGroupedBySuit)) return Constants.PokerHandNameFlush;
            if (IsHandAStraight(cardsGroupedByRank)) return Constants.PokerHandNameStraight;
            if (IsHandAThreeOfAKind(cardsGroupedByRank)) return Constants.PokerHandNameThreeOfAKind;
            if (IsHandATwoPair(cardsGroupedByRank)) return Constants.PokerHandNameTwoPair;
            if (IsHandAOnePair(cardsGroupedByRank)) return Constants.PokerHandNameOnePair;
            return Constants.PokerHandNameHighCard;
        }

        private static bool IsHandAOnePair(Dictionary<CardRank, int> cardsGroupedByRank)
        {
            return cardsGroupedByRank.Count(kvp => kvp.Value == 2) == 1;
        }

        private static bool IsHandATwoPair(Dictionary<CardRank, int> cardsGroupedByRank)
        {
            return cardsGroupedByRank.Count(kvp => kvp.Value == 2) == 2;
        }

        private static bool IsHandAThreeOfAKind(Dictionary<CardRank, int> cardsGroupedByRank)
        {
            return cardsGroupedByRank.Values.Max() == 3;
        }

        private static bool IsHandAFullHouse(Dictionary<CardRank, int> cardsGroupedByRank)
        {
            if (cardsGroupedByRank.ContainsValue(3)
                && cardsGroupedByRank.ContainsValue(2))
            {
                return true;
            }

            return false;
        }

        private static bool IsHandAFourOfAKind(Dictionary<CardRank, int> cardsGroupedByRank)
        {
            return cardsGroupedByRank.Values.Max() == 4;
        }

        private static bool IsHandAStraightFlush(Dictionary<CardRank, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            if (IsHandAStraight(cardsGroupedByRank)
                && IsHandAFlush(cardsGroupedBySuit))
            {
                return true;
            }

            return false;
        }

        private static bool IsHandARoyalFlush(Dictionary<CardRank, int> cardsGroupedByRank, Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            if (IsHandAStraightFlush(cardsGroupedByRank, cardsGroupedBySuit)
                && cardsGroupedByRank.Keys.Min() == CardRank.Ten)
            {
                return true;
            }

            return false;
        }

        private static bool IsHandAFlush(Dictionary<CardSuit, int> cardsGroupedBySuit)
        {
            return cardsGroupedBySuit.Values.Max() == Constants.NumberOfCardsInHand;
        }

        private static bool IsHandAStraight(Dictionary<CardRank, int> cardsGroupedByRank)
        {
            // Condition 1: Ensure each card rank is unique
            if (cardsGroupedByRank.Values.Max() == 1)
            {
                var highestRankedCard = cardsGroupedByRank.Keys.Max();
                var handContainsAce = highestRankedCard == CardRank.AceHigh;
                var lowestRankedCard = cardsGroupedByRank.Keys.Min();

                // Condition 2: Make sure all the cards are grouped together
                if (highestRankedCard - lowestRankedCard == (Constants.NumberOfCardsInHand - 1))
                {
                    return true;
                }

                // If the hand contained an ace, try again with aces low (compared against the second highest card).
                if (handContainsAce)
                {
                    lowestRankedCard = CardRank.AceLow;
                    highestRankedCard = cardsGroupedByRank.Keys
                        .Where(cardRank => cardRank != CardRank.AceHigh)
                        .Max();

                    if (highestRankedCard - lowestRankedCard == (Constants.NumberOfCardsInHand - 1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static Dictionary<CardSuit, int> GroupCardsBySuit(CardHand cardHand)
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

        private static Dictionary<CardRank, int> GroupCardsByRank(CardHand cardHand)
        {
            return cardHand.Cards
                .GroupBy(card => card.Rank)
                .Select(cardGroup => new
                {
                    Key = cardGroup.Key,
                    Val = cardGroup.Count()
                })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Val);
        }
    }
}