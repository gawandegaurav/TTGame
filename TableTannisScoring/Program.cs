using System;
using TableTennis.Console.Models;
using TableTennis.Console.Services;

namespace TableTennis.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string continuePlay;
            do
            {
                var playerOne = new Player("Ram");
                var playerTwo = new Player("Sham");

                System.Console.WriteLine($"Welcome to Table tannis game between  {playerOne.Name} and {playerTwo.Name} !!");

                var service = new TableTennisGameService();

                service.StartGame(playerOne, playerTwo);

                var winner = PlayGame(service);

                System.Console.WriteLine($"Winner of the game is {winner.Name} and his score {winner.Score}");
                System.Console.WriteLine("Do you want to play another game ? [Y,N]");

                continuePlay = System.Console.ReadLine();
            } while (string.Equals(continuePlay, "Y", StringComparison.OrdinalIgnoreCase));
        }

        private static Player PlayGame(TableTennisGameService service)
        {
            Player winner;

            while (true)
            {
                bool isPointForPlayerOne = GetPoint();

                service.UpdateScore(isPointForPlayerOne);

                if (service.CanEndGame())
                {
                    winner = service.GetWinner();
                    break;
                }
            }

            return winner;
        }

        private static bool GetPoint()
        {
            Random rnd = new Random();
            int number = rnd.Next(2, 10);

            var pointForPlayerOne = number % 2 == 0;
            return pointForPlayerOne;
        }
    }
}