using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TerribleAI
{
    public class Competitor
    {
        private Random _random;

        public Competitor(int x, int y, char color)
        {
        }


        public Move MakeMove(char[][] visableArea)
        { 
            MapObjects[][] parsedMap = ParseMap(visableArea);
            var move = new Move {Speed = _random.Next(1, 4)};
            var direction = _random.Next(0, 3);
            switch (direction)
            {
                case 0:
                    move.Direction = "North";
                    break;
                case 1:
                    move.Direction = "East";
                    break;
                case 2:
                    move.Direction = "West";
                    break;
                case 3:
                    move.Direction = "South";
                    break;

            }
            return move;
        }

        private MapObjects[][] ParseMap(char[][] visableArea)
        {
            return visableArea.Select(row => row.Select(CharToMapObject).ToArray()).ToArray();
        }

        private MapObjects CharToMapObject(char mapObject)
        {
            switch (mapObject)
            {
                case 'X': return MapObjects.Wall;
                case '-': return MapObjects.FreeSquare;
                case 'C': return MapObjects.Crash;
                default: return char.IsUpper(mapObject) ? MapObjects.Motorcycle : MapObjects.Track;
            }
            
        }
        enum MapObjects
        {
            FreeSquare,
            Wall,
            Crash,
            Motorcycle,
            Track
        }

    }


    public class Move
    {
        public string Direction { get; set; }
        public int Speed { get; set; }
    } 
}

