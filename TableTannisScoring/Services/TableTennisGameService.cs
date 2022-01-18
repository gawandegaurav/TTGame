using TableTennis.Console.Models;

namespace TableTennis.Console.Services
{
    public class TableTennisGameService : ITableTennisGameService
    {
        private TableTennisGame game;
        public TableTennisGameService()
        {
        }

        public void StartGame(Player PlayerOne, Player PlayerTwo)
        {
            game = new TableTennisGame(PlayerOne, PlayerTwo);
        }

        public void UpdateScore(bool isPointForPlayerOne)
        {
            game.UpdateScore(isPointForPlayerOne);
        }

        public bool CanEndGame()
        {
            return game.CanEndGame();
        }

        public Player GetWinner()
        {
            return game.GetWinner();
        }
    }
}
