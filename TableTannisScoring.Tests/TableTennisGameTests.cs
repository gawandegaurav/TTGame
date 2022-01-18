using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableTennis.Console.Models;

namespace TableTennis.Tests
{
    [TestClass]
    public class TableTennisGameTests
    {
        private readonly Player PlayerOne;
        private readonly Player PlayerTwo;
        private const string PlayerOneName = "PlayerOne";
        private const string PlayerTwoName = "PlayerTwo";

        private const bool PointToPlayerOne = true;

        public TableTennisGameTests()
        {
            PlayerOne = new Player(PlayerOneName);
            PlayerTwo = new Player(PlayerTwoName);
        }

        [TestMethod]
        public void GivenScoreIsNotTie_WhenPlayerOneScores11ThPoint_ThenPlayerOneIsWinner()
        {
            // Arrange

            PlayerOne.Score = 10;
            PlayerTwo.Score = 5;
            var game = new TableTennisGame(PlayerOne, PlayerTwo);
            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.GetWinner();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerOneName, result.Name);
            Assert.AreEqual(11, result.Score);
        }

        [TestMethod]
        public void GivenBothPlayersTieAt10Points_WhenAPlayerScores11ThPoint_ThenThereIsNoWinner()
        {
            // Arrange

            PlayerOne.Score = 9;
            PlayerTwo.Score = 10;

            var game = new TableTennisGame(PlayerOne, PlayerTwo);
            game.UpdateScore(PointToPlayerOne);
            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.CanEndGame();

            // Assert

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenBothPlayerHadTieAt10Points_WhenPlayerOneHasTwoPointLead_ThenPlayerOneIsReturedAsWinner()
        {
            // Arrange

            PlayerOne.Score = 10;
            PlayerTwo.Score = 10;

            var game = new TableTennisGame(PlayerOne, PlayerTwo);
            game.UpdateScore(PointToPlayerOne);
            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.GetWinner();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerOneName, result.Name);
            Assert.AreEqual(12, result.Score);
        }

        [TestMethod]
        public void GivenBothPlayerHadTieAt20Points_WhenPlayerOneHasOnePointLead_ThenPlayerOneIsReturedAsWinner()
        {
            // Arrange

            PlayerOne.Score = 20;
            PlayerTwo.Score = 20;

            var game = new TableTennisGame(PlayerOne, PlayerTwo);

            game.UpdateScore(PointToPlayerOne);

            // Act

            var result = game.GetWinner();

            // Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(PlayerOneName, result.Name);
            Assert.AreEqual(21, result.Score);
        }
    }
}