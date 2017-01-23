using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }

        public Board()
        {
            this.Tiles = new List<Tile>();
            GenerateTiles();
        }

        private void GenerateTiles()
        {
            Tile t = new Tile();
            t.Hit = false;
            t.Ship = false;
            t.id = "a1";
            t.x = 100;
            t.y = 100;
            Tiles.Add(t);
            t = new Tile();
            t.Hit = false;
            t.Ship = false;
            t.id = "a2";
            t.x = 200;
            t.y = 200;
            Tiles.Add(t);
        }
    }
}