using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TronBattle
{
    public class TronBattle
    {
        private Competitor[] _competitors;
        private readonly Dictionary<Competitor, char> _colourMap;
        readonly Random _random = new Random();
        private readonly Map _map;
        private int currentIndex;
        public TronBattle(Dictionary<string, char> aIs, string mapFile)
        {
            _competitors = new Competitor[aIs.Count];
            _colourMap = new Dictionary<Competitor, char>();
            _map = new Map(_random, mapFile);
            var index = 0;
            foreach (var color in aIs)
            {
                var coordinates = _map.RandomlyPlaceAi(color.Value);
                var competitor = new Competitor(color.Key, coordinates.X, coordinates.Y, color.Value);
                _colourMap.Add(competitor, color.Value);
                _competitors[index++] = competitor;
            }

        }

        public GameState GetInitialGameState()
        {
            return new GameState
            {
                LogEntry = "",
                Map = _map.Arena,
                IsOver = false,
                Winner = ""
 
            };
        }

        public GameState MakeNextMove()
        {
            var currentPlayer = _competitors[currentIndex];
            while (!currentPlayer.IsAlive)
            {
                currentIndex = ++currentIndex % _competitors.Length;
                currentPlayer = _competitors[currentIndex];
            }
            dynamic player1Move = null;
            currentIndex = ++currentIndex % _competitors.Length;
            var gameState = new GameState();
            var madeItInTime = Helpers.Helpers.ExecuteWithTimeLimit(new TimeSpan(0, 0, 0, 0, 250), () => player1Move = currentPlayer.ActualCompetitor.MakeMove(_map.GetVisableArea(currentPlayer)));
            if (!madeItInTime)
            {
                currentPlayer.IsAlive = false;
                _map.Arena[currentPlayer.CurrentXPosition][currentPlayer.CurrentYPosition] = 'C';
                gameState.LogEntry = currentPlayer.PlayerName + " did something illegal when making a move";
            }


            if (currentPlayer.IsAlive)
            {
                ChangeToLegalSpeed(player1Move);
                Direction direction;
                var canParse = TryParseDirection(player1Move.Direction, out direction);
                if (!canParse)
                {
                    currentPlayer.IsAlive = false;
                    gameState.LogEntry = currentPlayer.PlayerName + "gave a faulty direction when making a move";
                }
                string lossReason = MakeMove(currentPlayer, player1Move.Speed, direction);

                if (!string.IsNullOrEmpty(lossReason))
                {
                    gameState.LogEntry = lossReason;
                }
            }

            gameState.Map = _map.Arena;
            var count = _competitors.Count(comp => comp.IsAlive);
            gameState.IsOver = count < 2;
            if (!gameState.IsOver) return gameState;
            if (count != 1) return gameState;
            gameState.Winner = _competitors.Single(comp => comp.IsAlive).PlayerName;
            return gameState;
        }

        private bool TryParseDirection(string direction, out Direction direction1)
        {
            try
            {
                direction1 = (Direction) Enum.Parse(typeof(Direction), direction, true);
                return true;

            }
            catch (Exception)
            {
                
            }
            direction1 = Direction.East;
            return false;

        }

        private static void ChangeToLegalSpeed(dynamic player1Move)
        {
            if (player1Move.Speed < 1)
            {
                player1Move.Speed = 1;
            }
            else if (player1Move.Speed > 4)
            {
                player1Move.Speed = 4;
            }
        }

        private string MakeMove(Competitor player, int speed, Direction direction)
        {
            for (var i = 1; i <= speed; i++)
            {
                var finalX = player.CurrentXPosition;
                var finalY = player.CurrentYPosition;
                switch (direction)
                {
                    case Direction.North:
                        finalY -= 1;
                        break;
                    case Direction.South:
                        finalY += 1;
                        break;
                    case Direction.West:
                        finalX -= 1;
                        break;
                    case Direction.East:
                        finalX += 1;
                        break;
                }

                if (_map.IsOutsideMap(finalX,finalY))
                {
                    _map.Arena[player.CurrentXPosition][player.CurrentYPosition] = 'C';
                    player.IsAlive = false;

                    return $"{player.PlayerName} ran into a wall";
                }
                var mapColour = _map.GetCoordinate(finalX, finalY);
                if (mapColour == '-')
                {
                    _map.Arena[player.CurrentXPosition][player.CurrentYPosition] = player.Color;
                    player.CurrentXPosition = finalX;
                    player.CurrentYPosition = finalY;
                    _map.Arena[player.CurrentXPosition][player.CurrentYPosition] =  char.ToUpper(player.Color);
                    continue;
                }
                player.IsAlive = false;
                _map.Arena[player.CurrentXPosition][player.CurrentYPosition] = 'C';
                if (mapColour == 'X')
                {
                    return $"{player.PlayerName} ran into a wall";
                }
                if (mapColour == 'C')
                {
                    
                    return $"{player.PlayerName} ran into a crash";
                }
                var playerColour = char.ToLower(mapColour);
                var whoWasIt = mapColour == player.Color ? "their own" : _colourMap.Single(comp => comp.Key.Color == playerColour).Key.PlayerName + "'s tracks";
                return $"{player.PlayerName} ran into {whoWasIt} tracks";
            }
            return "";
        }
    }
}
