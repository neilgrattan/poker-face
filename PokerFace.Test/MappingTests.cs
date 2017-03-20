using NUnit.Framework;
using PokerFace.Mappings;
using PokerFace.Model;

namespace PokerFace.Test
{
    [TestFixture]
    public class MappingTests
    {
        [Test]
        public void MapStringArrayToCardHand_WithInsuffientStrings_ReturnsNull()
        {
            var cardHand = MapStringToCardHand.Map(new[]
            {
                "2C"  // Should be 5 of these
            });

            Assert.AreEqual(null, cardHand);
        }

        [Test]
        public void MapStringArrayToCardHand_WithUnknownFace_ReturnsNull()
        {
            var cardHand = MapStringToCardHand.Map(new[]
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
        public void MapStringArrayToCardHand_WithUnknownSuit_ReturnsNull()
        {
            var cardHand = MapStringToCardHand.Map(new[]
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
        public void MapStringArrayToCardHand_WithUnexpectedChar_ReturnsNull()
        {
            var cardHand = MapStringToCardHand.Map(new[]
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
        public void MapStringArrayToCardHand_WithValidCards_ReturnsValidCardHand()
        {
            var cardHand = MapStringToCardHand.Map(new[]
            {
                "2C",
                "TD",
                "AH",
                "5S",
                "2D"
            });

            Assert.AreEqual(5, cardHand.Cards.Count);

            Assert.AreEqual(CardRank.Two, cardHand.Cards[0].Rank);
            Assert.AreEqual(CardSuit.Clubs, cardHand.Cards[0].Suit);

            Assert.AreEqual(CardRank.Ten, cardHand.Cards[1].Rank);
            Assert.AreEqual(CardSuit.Diamonds, cardHand.Cards[1].Suit);

            Assert.AreEqual(CardRank.AceHigh, cardHand.Cards[2].Rank);
            Assert.AreEqual(CardSuit.Hearts, cardHand.Cards[2].Suit);

            Assert.AreEqual(CardRank.Five, cardHand.Cards[3].Rank);
            Assert.AreEqual(CardSuit.Spades, cardHand.Cards[3].Suit);

            Assert.AreEqual(CardRank.Two, cardHand.Cards[4].Rank);
            Assert.AreEqual(CardSuit.Diamonds, cardHand.Cards[4].Suit);
        }

        [Test]
        public void MapStringToCardHand_WithValidCardsInOneString_ReturnsValidCardHand()
        {
            var cardHand = MapStringToCardHand.Map("2C TD AH 5S 2D");

            Assert.AreEqual(5, cardHand.Cards.Count);

            Assert.AreEqual(CardRank.Two, cardHand.Cards[0].Rank);
            Assert.AreEqual(CardSuit.Clubs, cardHand.Cards[0].Suit);

            Assert.AreEqual(CardRank.Ten, cardHand.Cards[1].Rank);
            Assert.AreEqual(CardSuit.Diamonds, cardHand.Cards[1].Suit);

            Assert.AreEqual(CardRank.AceHigh, cardHand.Cards[2].Rank);
            Assert.AreEqual(CardSuit.Hearts, cardHand.Cards[2].Suit);

            Assert.AreEqual(CardRank.Five, cardHand.Cards[3].Rank);
            Assert.AreEqual(CardSuit.Spades, cardHand.Cards[3].Suit);

            Assert.AreEqual(CardRank.Two, cardHand.Cards[4].Rank);
            Assert.AreEqual(CardSuit.Diamonds, cardHand.Cards[4].Suit);
        }
    }
}