using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class GameState
    {
        public Guid GameGuid = Guid.NewGuid();

        public bool BothPlayersReady { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}