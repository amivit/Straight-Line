using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Controllers
{
    public class ApiController : Controller
    {
        //
        // POST: /Api/Git
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GitPull([FromBody]dynamic data)
        {
            try
            {
                var testJsonResult = JsonConvert.DeserializeObject(data.ToString());
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}