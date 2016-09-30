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
        // This method is called when appveyor succesfully finishes a build on the master branch (check after_deploy in appveyor.yml)
        // It starts a script to update to the latest version that appveyor has already build and uploaded to S3 for us
        // TODO: Encrypt the key in appveyor.yml
        // POST: /Api/GitPullUpdateServer
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GitPullUpdateServer([FromBody]dynamic data)
        {
            try
            {
                var testJsonResult = JsonConvert.DeserializeObject(data.ToString());
                Process.Start("/bin/bash -c /home/ubuntu/mvc-run/update.sh");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}