using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class GameState
    {
        public GameState()
        {
            this.Player1 = new Player();
            this.Player2 = new Player();
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
    }
}