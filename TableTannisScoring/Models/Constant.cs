using System.Collections.Generic;

namespace TableTennis.Console.Models
{
    public static class Constant
    {
        public static readonly List<int> WinningScore = new List<int> { 11, 21 };
        public static readonly int PointDifferenceToWin = 2;
        public static readonly int TiePoint10 = 10;
        public static readonly int TiePoint20 = 20;
    }
}