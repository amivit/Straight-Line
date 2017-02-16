using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraightLine.Models.Battleship;

namespace StraightLine.Controllers.Battleship
{
    public class BattleshipController : Controller
    {
        private static Stack<GameState> _gameStateStack;
        private static GameState _activeGameState;

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

        [Route("api/Load")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Load()
        {
            _activeGameState = null;
            if (_gameStateStack == null)
            { _gameStateStack = new Stack<GameState>(); }

            foreach (var gameState in _gameStateStack) // Find existing game, if any
            {
                if (HttpContext.Session.GetString("GameGUID") == gameState.GameGuid.ToString())
                { _activeGameState = gameState; }
            }

            if (_gameStateStack.Count != 0 && _gameStateStack.Peek().Player2 == null && _gameStateStack.Peek().Player1.PlayerGuid.ToString() != HttpContext.Session.GetString("PlayerGUID"))
            {
                _activeGameState = _gameStateStack.Peek();
                _activeGameState.Player2 = new Player();
                _activeGameState.Player2.GameGuid = _activeGameState.GameGuid;
                HttpContext.Session.SetString("PlayerGUID", _activeGameState.Player2.PlayerGuid.ToString());
            }
            else if (_activeGameState == null) // No existing game waiting on 2nd player
            {
                _activeGameState = new GameState();
                _activeGameState.Player1 = new Player();
                _activeGameState.Player1.GameGuid = _activeGameState.GameGuid;

                _gameStateStack.Push(_activeGameState);
                HttpContext.Session.SetString("PlayerGUID", _activeGameState.Player1.PlayerGuid.ToString());
            }

            HttpContext.Session.SetString("GameGUID", _activeGameState.GameGuid.ToString());

            if (HttpContext.Session.GetString("PlayerGUID") == _activeGameState.Player1.PlayerGuid.ToString())
            {
                return Ok(_activeGameState.Player1);
            }
            else if (HttpContext.Session.GetString("PlayerGUID") == _activeGameState.Player2.PlayerGuid.ToString())
            {
                return Ok(_activeGameState.Player2);
            }
            return BadRequest();
        }

        [Route("api/GameStart/{PlayerGuid}")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GameStart(string PlayerGuid)
        {
            if (PlayerGuid == _activeGameState.Player1.PlayerGuid.ToString())
            {
                _activeGameState.Player1.Ready = true;
            }
            else if (PlayerGuid == _activeGameState.Player2.PlayerGuid.ToString())
            {
                _activeGameState.Player2.Ready = true;
            }

            //if (_activeGameState.Player1.Ready == true && _activeGameState.Player2.Ready == true)
            //{

            //}

                return Ok(_activeGameState);
        }

        [Route("api/Reset")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return Ok();
        }
    }
}