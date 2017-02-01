using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class Ship
    {
        public string id { get; set; }
        public List<Tile> placement { get; set; }

        public int lenght { get; set; }

        public bool clicked { get; set; }
        public string colour { get; set; }

        public int x { get; set; }

        public int y { get; set; }
    }
}