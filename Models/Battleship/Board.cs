using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Models.Battleship
{
    public class Board
    {
        private Tile t;
        private Ship s;
        public List<Tile> Tiles { get; set; }
        public  List<Ship> Ships { get; set; } 

        public Board()
        {
            this.Tiles = new List<Tile>();
            this.Ships = new List<Ship>();
            GenerateTiles();
            GenerateShips();
        }

        private void GenerateTiles()
        {
            int teller = 0;
            int x = 0;
            int y = 50;
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    t = new Tile();
                    t.Hit = false;
                    t.Ship = false;
                    t.id = teller.ToString();
                    t.x = x + 50;
                    x = t.x;
                    t.y = y;
                    Tiles.Add(t);
                    teller = teller + 1;
                }
                y = y + 50;
                x = 0;
            }
        }

        private void GenerateShips()
        {
            s = new Ship();
            s.id = 0.ToString();
            s.lenght = 3;
            s.x = 50;
            s.y = 600;
            Ships.Add(s);

            s = new Ship();
            s.id = 1.ToString();
            s.lenght = 2;
            s.x = 150;
            s.y = 600;
            Ships.Add(s);

            s = new Ship();
            s.id = 2.ToString();
            s.lenght = 1;
            s.x = 250;
            s.y = 600;
            Ships.Add(s);


        }
    }
}