using System.Collections.Generic;
using System.Drawing;

namespace TronBattle
{
    public class GameState
    {
        public char[][] Map { get; set; }
        public bool IsOver { get; set; }
        public string Winner { get; set; }
        public string LogEntry { get; set; }
    }
}