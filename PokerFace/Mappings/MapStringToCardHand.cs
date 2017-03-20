using System.Collections.Generic;
using PokerFace.Model;

namespace PokerFace.Mappings
{
    public static class MapStringToCardHand
    {
        public static CardHand Map(string concatenatedString)
        {
            return Map(concatenatedString.Split(' '));
        }

        public static CardHand Map(string[] strings)
        {
            if (strings.Length != Constants.NumberOfCardsInHand)
            {
                return null;
            }

            var cardHand = new CardHand()
            {
                Cards = new List<Card>()
            };

            foreach (var cardString in strings)
            {
                var card = MapCardStringToCard(cardString);
                if (card != null)
                {
                    cardHand.Cards.Add(card);
                }
                else
                {
                    // No point continuing if not all cards can be read
                    break;
                }
            }

            return cardHand.Cards.Count != Constants.NumberOfCardsInHand ? null : cardHand;
        }

        private static Card MapCardStringToCard(string cardString)
        {
            if (cardString.Length != 2)
            {
                return null;
            }

            var face = MapCharToCardFace(cardString[0]);
            var suit = MapCharToCardSuit(cardString[1]);

            return !face.HasValue || !suit.HasValue
                ? null
                : new Card()
                {
                    Rank = face.Value,
                    Suit = suit.Value
                };
        }

        private static CardRank? MapCharToCardFace(char faceChar)
        {
            // Could have been implemented using Enum.IsDefined and some
            // custom attributes for string values (to map non-numeric face
            // values) - However this would use reflection and this call is
            // in a tight loop.

            switch (faceChar)
            {
                case '2':
                    return CardRank.Two;

                case '3':
                    return CardRank.Three;

                case '4':
                    return CardRank.Four;

                case '5':
                    return CardRank.Five;

                case '6':
                    return CardRank.Six;

                case '7':
                    return CardRank.Seven;

                case '8':
                    return CardRank.Eight;

                case '9':
                    return CardRank.Nine;

                case 'T':
                    return CardRank.Ten;

                case 'J':
                    return CardRank.Joker;

                case 'Q':
                    return CardRank.Queen;

                case 'K':
                    return CardRank.King;

                case 'A':
                    return CardRank.Ace;

                default:
                    return null;
            }
        }

        private static CardSuit? MapCharToCardSuit(char suitChar)
        {
            switch (suitChar)
            {
                case 'H':
                    return CardSuit.Hearts;

                case 'D':
                    return CardSuit.Diamonds;

                case 'S':
                    return CardSuit.Spades;

                case 'C':
                    return CardSuit.Clubs;

                default:
                    return null;
            }
        }
    }
}