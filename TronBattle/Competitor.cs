using System;
using System.Drawing;
using System.Linq;

namespace TronBattle
{
    internal class Competitor
    {

        public Competitor(string containingAssembly, int startingXCoordinate, int startingYCoordinate, char color)
        {
            ActualCompetitor = Helpers.Helpers.ActivateFromAssembly(containingAssembly, startingXCoordinate, startingYCoordinate, color);
            CurrentXPosition = startingXCoordinate;
            CurrentYPosition = startingYCoordinate;
            var temp = containingAssembly.Split('\\').Last();
            PlayerName = temp.Substring(0,temp.Length-4);
            IsAlive = true;
            Color = color;
        }

        public dynamic ActualCompetitor { get; set; }
        public int CurrentXPosition { get; set; }
        public int CurrentYPosition { get; set; }
        public string PlayerName { get; set; }
        public bool IsAlive { get; set; }
        public char Color { get; set; }
    }
}