using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StraightLine.Controllers
{
    public class ApiController : Controller
    {
        //
        // POST: /Api/GitPullUpdateServer
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GitPullUpdateServer([FromBody]dynamic data)
        {
            try
            {
                var testJsonResult = JsonConvert.DeserializeObject(data.ToString());
                Process.Start("/bin/sh", "/home/ubuntu/mvc-run/update.sh");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}