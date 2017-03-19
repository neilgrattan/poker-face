using NUnit.Framework;
using NSubstitute;

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
    }
}