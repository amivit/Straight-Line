using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StraightLine.Models.Battleship;

namespace StraightLine.Controllers.Battleship
{
    public class BattleshipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/Bomb/{position}")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Bomb(string position)
        {
            var gameState = new GameState();

            return Ok(gameState);
        }

        [Route("api/PlaceShip/{position}/{horizontal}")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult PlaceShip(string position, bool horizontal)
        {
            return Ok();
        }
    }
}