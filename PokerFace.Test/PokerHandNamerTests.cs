using System.Collections.Generic;
using NUnit.Framework;
using PokerFace.Model;

namespace PokerFace.Test
{
    [TestFixture]
    internal class PokerHandNamerTests
    {
        private readonly CardHand _highCardHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Five, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Joker, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _onePairHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _twoPairHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _threeOfAKindHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _lowStraightHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Five, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.Four, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _middleStraightHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Six, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Five, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Four, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _highStraightHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Queen, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Joker, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.King, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _flushHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Joker, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.King, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _fullHouseHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.King, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.King, Suit = CardSuit.Hearts}
            }
        };

        private readonly CardHand _fourOfAKindHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Spades},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Hearts},
                new Card() {Rank = CardRank.King, Suit = CardSuit.Hearts}
            }
        };

        private readonly CardHand _straightFlushHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Four, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Five, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _royalFlushHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.Queen, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.King, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Ten, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Joker, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _straightWrappingNegativeTestHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.King, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Four, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _straightWrappingCombinationTestHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Rank = CardRank.King, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.AceHigh, Suit = CardSuit.Diamonds},
                new Card() {Rank = CardRank.Two, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Three, Suit = CardSuit.Clubs},
                new Card() {Rank = CardRank.Four, Suit = CardSuit.Clubs}
            }
        };

        [Test]
        public void PokerHandNamer_CalledWithEachHandSeparately_ReturnsCorrectResult()
        {
            var pokerHandNamer = new PokerHandNamer();

            Assert.AreEqual(Constants.PokerHandNameHighCard, pokerHandNamer.GetPokerHandNameForCardHand(_highCardHand));
            Assert.AreEqual(Constants.PokerHandNameOnePair, pokerHandNamer.GetPokerHandNameForCardHand(_onePairHand));
            Assert.AreEqual(Constants.PokerHandNameTwoPair, pokerHandNamer.GetPokerHandNameForCardHand(_twoPairHand));
            Assert.AreEqual(Constants.PokerHandNameThreeOfAKind, pokerHandNamer.GetPokerHandNameForCardHand(_threeOfAKindHand));
            Assert.AreEqual(Constants.PokerHandNameStraight, pokerHandNamer.GetPokerHandNameForCardHand(_lowStraightHand));
            Assert.AreEqual(Constants.PokerHandNameStraight, pokerHandNamer.GetPokerHandNameForCardHand(_middleStraightHand));
            Assert.AreEqual(Constants.PokerHandNameStraight, pokerHandNamer.GetPokerHandNameForCardHand(_highStraightHand));
            Assert.AreEqual(Constants.PokerHandNameFlush, pokerHandNamer.GetPokerHandNameForCardHand(_flushHand));
            Assert.AreEqual(Constants.PokerHandNameFullHouse, pokerHandNamer.GetPokerHandNameForCardHand(_fullHouseHand));
            Assert.AreEqual(Constants.PokerHandNameFourOfAKind, pokerHandNamer.GetPokerHandNameForCardHand(_fourOfAKindHand));
            Assert.AreEqual(Constants.PokerHandNameStraightFlush, pokerHandNamer.GetPokerHandNameForCardHand(_straightFlushHand));
            Assert.AreEqual(Constants.PokerHandNameRoyalFlush, pokerHandNamer.GetPokerHandNameForCardHand(_royalFlushHand));
        }

        [Test]
        public void PokerHandNamer_CalledWithHandThatLooksLikeStraightWillWrap_ReturnsHighCardInstead()
        {
            var pokerHandNamer = new PokerHandNamer();

            Assert.AreEqual(Constants.PokerHandNameHighCard, pokerHandNamer.GetPokerHandNameForCardHand(_straightWrappingNegativeTestHand));
        }
    }
}