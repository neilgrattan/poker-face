using System.Collections.Generic;
using PokerFace.Model;

namespace PokerFace.Mappings
{
    public static class MapStringArrayToCardHand
    {
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
                var card = MapStringToCard(cardString);
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

        private static Card MapStringToCard(string cardString)
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
                    Face = face.Value,
                    Suit = suit.Value
                };
        }

        private static CardFace? MapCharToCardFace(char faceChar)
        {
            // Could have been implemented using Enum.IsDefined and some
            // custom attributes for string values (to map non-numeric face
            // values) - However this would use reflection and this call is
            // in a tight loop.

            switch (faceChar)
            {
                case '2':
                    return CardFace.Two;

                case '3':
                    return CardFace.Three;

                case '4':
                    return CardFace.Four;

                case '5':
                    return CardFace.Five;

                case '6':
                    return CardFace.Six;

                case '7':
                    return CardFace.Seven;

                case '8':
                    return CardFace.Eight;

                case '9':
                    return CardFace.Nine;

                case 'T':
                    return CardFace.Ten;

                case 'J':
                    return CardFace.Joker;

                case 'Q':
                    return CardFace.Queen;

                case 'K':
                    return CardFace.King;

                case 'A':
                    return CardFace.Ace;

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