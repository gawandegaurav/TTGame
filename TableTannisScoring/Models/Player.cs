using System;

namespace TableTennis.Console.Models
{
    public class Player
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Score { get; set; }

        public Player(string name)
        {
            Id = new Guid();
            Name = name;
        }
    }
}