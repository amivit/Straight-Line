using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
        public Guid PlayerGuid = Guid.NewGuid();
        public Guid GameGuid;
    }
}