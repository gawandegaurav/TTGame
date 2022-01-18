using System;
namespace TableTennis.Console.Models
{
    public class TableTennisGame
    {
        private readonly Player PlayerOne;
        private readonly Player PlayerTwo;
        private Player Winner;
        private bool Need2PointsLead;
        private bool HasWinner;

        public TableTennisGame(Player playerOne, Player playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public Player GetWinner()
        {
            return Winner;
        }

        public bool CanEndGame()
        {
            return HasWinner;
        }

        public void UpdateScore(bool isPointForPlayerOne)
        {
            if (isPointForPlayerOne)
            {
                PlayerOne.Score++;
            }
            else
            {
                PlayerTwo.Score++;
            }

            HasWinner = GameHasWinner();
            System.Console.WriteLine($"{PlayerOne.Name} - {PlayerOne.Score}  {PlayerTwo.Name} - {PlayerTwo.Score}");
        }

        private bool GameHasWinner()
        {
            CheckForTie();

            var playerOneScore = PlayerOne.Score;
            var playerTwoScore = PlayerTwo.Score;

            if (Need2PointsLead)
            {
                if (playerOneScore - playerTwoScore == Constant.PointDifferenceToWin)
                {
                    Winner = PlayerOne;
                    return true;
                }
                else if (playerTwoScore - playerOneScore == Constant.PointDifferenceToWin)
                {
                    Winner = PlayerTwo;
                    return true;
                }
            }
            else if (Constant.WinningScore.Contains(playerOneScore))
            {
                Winner = PlayerOne;
                return true;
            }
            else if (Constant.WinningScore.Contains(playerTwoScore))
            {
                Winner = PlayerTwo;
                return true;
            }

            return false;
        }

        private void CheckForTie()
        {
            var isTieAt10Points = PlayerOne.Score == Constant.TiePoint10 && PlayerTwo.Score == Constant.TiePoint10;
            var isTieAt20Points = PlayerOne.Score == Constant.TiePoint20 && PlayerTwo.Score == Constant.TiePoint20;

            if (isTieAt10Points)
            {
                Need2PointsLead = true;
            }
            else if (isTieAt20Points)
            {
                Need2PointsLead = false;
            }
        }
    }
}