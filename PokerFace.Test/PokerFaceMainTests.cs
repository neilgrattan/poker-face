using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using PokerFace.Model;

namespace PokerFace.Test
{
    [TestFixture]
    public class PokerFaceMainTests
    {
        //Mocks
        private ICardHandsFileReader _cardHandsFileReader;

        [SetUp]
        protected void SetUp()
        {
            _cardHandsFileReader = Substitute.For<ICardHandsFileReader>();
        }

        [Test]
        public void PokerFaceMain_FileNotFound_ExitsEarly()
        {
            // Arrange
            _cardHandsFileReader.FileExists().Returns(false);
            var pokerFaceMain = new PokerFaceMain(_cardHandsFileReader);

            // Act
            var result = pokerFaceMain.EvaluateHands();

            // Assert
            Assert.AreEqual((int)Constants.ExitStatusCode.InputFileNotFound, result);
        }

        [Test]
        public void PokerFaceMain_FileHasOneValidCardHand_EvaluatesOneHandAndEnds()
        {
            // Arrange
            var cardHandLine = "2D 3D 4D 5D 6D";
            var cardHand = new CardHand()
            {
                Cards = new List<Card>()
                {
                    new Card() {Face = CardFace.Two, Suit = CardSuit.Diamonds},
                    new Card() {Face = CardFace.Three, Suit = CardSuit.Diamonds},
                    new Card() {Face = CardFace.Four, Suit = CardSuit.Diamonds},
                    new Card() {Face = CardFace.Five, Suit = CardSuit.Diamonds},
                    new Card() {Face = CardFace.Six, Suit = CardSuit.Diamonds}
                }
            };

            _cardHandsFileReader.FileExists().Returns(false);
            _cardHandsFileReader.AtEndOfFile().Returns(false, true);
            _cardHandsFileReader.ReadNextCardHandLine().Returns(cardHandLine);
            var pokerFaceMain = new PokerFaceMain(_cardHandsFileReader);

            // Act
            var result = pokerFaceMain.EvaluateHands();

            // Assert
            Assert.AreEqual((int)Constants.ExitStatusCode.Success, result);
            _cardHandsFileReader.Received(1).CloseFile();
        }
    }
}