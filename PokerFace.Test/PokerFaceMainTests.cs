using NUnit.Framework;
using NSubstitute;

namespace PokerFace.Test
{
    [TestFixture]
    public class PokerFaceMainTests
    {
        //Mocks
        private ICardHandsFileReader cardHandsFileReader;

        [SetUp]
        protected void SetUp()
        {
            cardHandsFileReader = Substitute.For<ICardHandsFileReader>();
        }

        [Test]
        public void PokerFaceMain_FileNotFound_ExitsEarly()
        {
            // Arrange
            cardHandsFileReader.FileExists().Returns(false);
            var pokerFaceMain = new PokerFaceMain(cardHandsFileReader);

            // Act
            var result = pokerFaceMain.EvaluateHands();

            // Assert
            Assert.AreEqual((int)Constants.ExitStatusCode.INPUT_FILE_NOT_FOUND, result);
        }
    }
}