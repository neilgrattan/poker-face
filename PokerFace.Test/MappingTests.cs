using System.Collections.Generic;
using NUnit.Framework;
using PokerFace.Mappings;
using PokerFace.Model;

namespace PokerFace.Test
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void MapStringArrayToCardHand_InsuffientStrings_ReturnsNull()
        {
            var cardHand = MapStringArrayToCardHand.Map(new[]
            {
                "2C"  // Should be 5 of these
            });

            Assert.AreEqual(null, cardHand);
        }

        [Test]
        public void MapStringArrayToCardHand_UnknownFace_ReturnsNull()
        {
            var cardHand = MapStringArrayToCardHand.Map(new[]
            {
                "2C",
                "XH",  // Doesn't exist
                "AH",
                "5S",
                "2D",
            });

            Assert.AreEqual(null, cardHand);
        }

        [Test]
        public void MapStringArrayToCardHand_UnknownSuit_ReturnsNull()
        {
            var cardHand = MapStringArrayToCardHand.Map(new[]
            {
                "2C",
                "JX",  // Doesn't exist
                "AH",
                "5S",
                "2D",
            });

            Assert.AreEqual(null, cardHand);
        }

        [Test]
        public void MapStringArrayToCardHand_UnexpectedChar_ReturnsNull()
        {
            var cardHand = MapStringArrayToCardHand.Map(new[]
            {
                "2CX",  // Doesn't exist
                "JS",
                "AH",
                "5S",
                "2D",
            });

            Assert.AreEqual(null, cardHand);
        }

        [Test]
        public void MapStringArrayToCardHand_ValidCards_ReturnsValidCardHand()
        {
            var cardHand = MapStringArrayToCardHand.Map(new[]
            {
                "2C",
                "TD",
                "AH",
                "5S",
                "2D"
            });

            Assert.AreEqual(5, cardHand.Cards.Count);

            Assert.AreEqual(CardFace.Two, cardHand.Cards[0].Face);
            Assert.AreEqual(CardSuit.Clubs, cardHand.Cards[0].Suit);

            Assert.AreEqual(CardFace.Ten, cardHand.Cards[1].Face);
            Assert.AreEqual(CardSuit.Diamonds, cardHand.Cards[1].Suit);

            Assert.AreEqual(CardFace.Ace, cardHand.Cards[2].Face);
            Assert.AreEqual(CardSuit.Hearts, cardHand.Cards[2].Suit);

            Assert.AreEqual(CardFace.Five, cardHand.Cards[3].Face);
            Assert.AreEqual(CardSuit.Spades, cardHand.Cards[3].Suit);

            Assert.AreEqual(CardFace.Two, cardHand.Cards[4].Face);
            Assert.AreEqual(CardSuit.Diamonds, cardHand.Cards[4].Suit);
        }
    }
}