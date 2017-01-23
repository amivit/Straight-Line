using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class Tile
    {
        public string id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool Ship { get; set; }
        public bool Hit { get; set; }
    }
}