using TableTennis.Console.Models;

namespace TableTennis.Console.Services
{
    internal interface ITableTennisGameService
    {
        void StartGame(Player PlayerOne, Player PlayerTwo);

        void UpdateScore(bool pointToPlayerOne);

        bool CanEndGame();

        Player GetWinner();
    }
}