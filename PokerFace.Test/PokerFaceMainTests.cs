using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using NSubstitute;
using PokerFace.File;
using PokerFace.Model;

namespace PokerFace.Test
{
    [TestFixture]
    public class PokerFaceMainTests
    {
        // Mocks
        private ICardHandsFileReader _cardHandsFileReader;

        // Implementations
        private IPokerHandNamer _pokerHandNamer;

        [SetUp]
        protected void SetUp()
        {
            _cardHandsFileReader = Substitute.For<ICardHandsFileReader>();
            _pokerHandNamer = new PokerHandNamer();
        }

        [Test]
        public void PokerFaceMain_FileNotFound_ExitsEarly()
        {
            // Arrange
            _cardHandsFileReader.FileExists().Returns(false);
            var pokerFaceMain = new PokerFaceMain(_cardHandsFileReader, _pokerHandNamer);

            // Act
            var result = pokerFaceMain.EvaluateHands();

            // Assert
            Assert.AreEqual((int)Constants.ExitStatusCode.InputFileNotFound, result);
        }

        [Test]
        public void PokerFaceMain_FileHasTwoValidCardHands_EvaluatesBothHandsAndEnds()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Arrange
                const string cardHandLine1 = "2D 3D 4D 5D 6D";
                const string cardHandLine2 = "2C 3C 4C 5C 6C";

                _cardHandsFileReader.FileExists().Returns(true);
                _cardHandsFileReader.AtEndOfFile().Returns(false, false, true);
                _cardHandsFileReader.ReadNextCardHandLine().Returns(cardHandLine1, cardHandLine2);

                var pokerFaceMain = new PokerFaceMain(_cardHandsFileReader, _pokerHandNamer);

                // Act
                var result = pokerFaceMain.EvaluateHands();

                // Assert
                Assert.AreEqual((int)Constants.ExitStatusCode.Success, result);
                _cardHandsFileReader.Received(1).CloseFile();
                Assert.AreEqual("2D 3D 4D 5D 6D => Straight flush\r\n2C 3C 4C 5C 6C => Straight flush\r\n", sw.ToString());
            }

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }
    }
}