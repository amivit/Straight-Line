using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class Player
    {
        public Player()
        {
            this.Board = new Board();
        }

        public Board Board { get; set; }
        public bool Ready { get; set; }
    }
}