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
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Five, Suit = CardSuit.Diamonds},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Joker, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _onePairHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Diamonds},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _twoPairHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _threeOfAKindHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Three, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _lowStraightHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Five, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.Four, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _middleStraightHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Six, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Five, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Diamonds},
                new Card() {Face = CardFace.Four, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _highStraightHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Queen, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Joker, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.King, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Diamonds}
            }
        };

        private readonly CardHand _flushHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Joker, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.King, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _fullHouseHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Diamonds},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.King, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.King, Suit = CardSuit.Hearts}
            }
        };

        private readonly CardHand _fourOfAKindHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Diamonds},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Spades},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Hearts},
                new Card() {Face = CardFace.King, Suit = CardSuit.Hearts}
            }
        };

        private readonly CardHand _straightFlushHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Four, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Five, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _royalFlushHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.Queen, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.King, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ten, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Joker, Suit = CardSuit.Clubs}
            }
        };

        private readonly CardHand _straightWrappingNegativeTestHand = new CardHand()
        {
            Cards = new List<Card>()
            {
                new Card() {Face = CardFace.King, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Ace, Suit = CardSuit.Diamonds},
                new Card() {Face = CardFace.Two, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Three, Suit = CardSuit.Clubs},
                new Card() {Face = CardFace.Four, Suit = CardSuit.Clubs}
            }
        };

        [Test]
        public void PokerHandNamer_CalledWithEachHandSeparately_ReturnsCorrectResult()
        {
            var pokerHandNamer = new PokerHandNamer();

            Assert.AreEqual(Constants.PokerHandHighCard, pokerHandNamer.Name(_highCardHand));
            Assert.AreEqual(Constants.PokerHandOnePair, pokerHandNamer.Name(_onePairHand));
            Assert.AreEqual(Constants.PokerHandTwoPair, pokerHandNamer.Name(_twoPairHand));
            Assert.AreEqual(Constants.PokerHandThreeOfAKind, pokerHandNamer.Name(_threeOfAKindHand));
            Assert.AreEqual(Constants.PokerHandStraight, pokerHandNamer.Name(_lowStraightHand));
            Assert.AreEqual(Constants.PokerHandStraight, pokerHandNamer.Name(_middleStraightHand));
            Assert.AreEqual(Constants.PokerHandStraight, pokerHandNamer.Name(_highStraightHand));
            Assert.AreEqual(Constants.PokerHandFlush, pokerHandNamer.Name(_flushHand));
            Assert.AreEqual(Constants.PokerHandFullHouse, pokerHandNamer.Name(_fullHouseHand));
            Assert.AreEqual(Constants.PokerHandFourOfAKind, pokerHandNamer.Name(_fourOfAKindHand));
            Assert.AreEqual(Constants.PokerHandStraightFlush, pokerHandNamer.Name(_straightFlushHand));
            Assert.AreEqual(Constants.PokerHandStraightFlush, pokerHandNamer.Name(_royalFlushHand));
        }

        [Test]
        public void PokerHandNamer_CalledWithHandThatLooksLikeStraightWillWrap_ReturnsHighCardInstead()
        {
            var pokerHandNamer = new PokerHandNamer();

            Assert.AreEqual(Constants.PokerHandHighCard, pokerHandNamer.Name(_straightWrappingNegativeTestHand));
        }
    }
}