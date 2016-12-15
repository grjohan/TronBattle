using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TronBattle
{
    public class Map
    {
        private readonly Random _generator;
        public char[][] Arena { get;}
        public Map(Random generator, string mapfile)
        {
            _generator = generator;
            var map = File.ReadAllLines(mapfile);
            Arena = map.Select(row => row.ToArray()).ToArray();
        }


        internal bool TryColorSquare(char color, int x, int y)
        {

            var isNow = Arena[x][y];
            if (isNow != '-')
            {
                Arena[x][y] = 'C';
                return false;
            }
            Arena[x][y] = color;
            return true;
        }

        internal char GetCoordinate(int x, int y)
        {
            return IsOutsideMap(x,y) ? 'X' : Arena[x][y];
        }

        internal char[][] GetVisableArea(Competitor competitor)
        {
            var wholeThing = new List<char[]>();
            for (int x = competitor.CurrentXPosition - 2; x <= competitor.CurrentXPosition + 2; x++)
            {
                var thisRow = new List<char>();
                for (int y = competitor.CurrentYPosition - 2; y <= competitor.CurrentYPosition + 2; y++)
                {
                    thisRow.Add(GetCoordinate(x, y));
                }
                wholeThing.Add(thisRow.ToArray());
            }
            return wholeThing.ToArray();
        }

        internal bool IsOutsideMap(int x, int y)
        {
            return x > 49 || y > 49 || x < 0 || y < 0;
        }

        public Coordinate RandomlyPlaceAi(char value)
        {
            var coords = new Coordinate
            {
                X = _generator.Next(49),
                Y = _generator.Next(49)
            };
            if (Arena[coords.X][coords.Y] != '-')
            {
                coords = RandomlyPlaceAi(value);
            }
            else
            {
                Arena[coords.X][coords.Y] = char.ToUpper(value);
            }
            return coords;
        }
    }

    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}