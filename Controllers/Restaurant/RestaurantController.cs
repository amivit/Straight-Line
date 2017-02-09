using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StraightLine.Models;
using StraightLine.Models.Battleship;

namespace StraightLine.Controllers.Restaurant
{
    public class RestaurantController : Controller
    {
        private static RestaurantModel _restaurant;

        public RestaurantController()
        {
            if (_restaurant == null)
            { _restaurant = new RestaurantModel(); }
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/Restaurant/{tableNumber}/{occupied}")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ChangeOccupance(string tableNumber, bool occupied)
        {
            var table = RestaurantModel.TableList.FirstOrDefault(x => x.TableNumber == Convert.ToInt32(tableNumber));
            table.Occupied = occupied;

            return Ok(RestaurantModel.TableList);
        }

        [Route("api/Restaurant")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Restaurant()
        {
            return Ok(RestaurantModel.TableList);
        }
    }
}