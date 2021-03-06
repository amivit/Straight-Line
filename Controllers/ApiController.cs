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
        // TODO: Validate the call
        // POST: /Api/GitPullUpdateServer
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GitPullUpdateServer([FromBody]dynamic data)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "/usr/bin/nohup";
            psi.UseShellExecute = true;
            psi.RedirectStandardOutput = false;
            psi.Arguments = @"/usr/bin/sudo service supervisor restart &"; // DO NOT TOUCH. It works perfectly like this.
            Process.Start(psi);
            return Ok();
        }

        public static List<object> ObjectList { get; set; }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ObjectList);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] List<object> item)
        {
            // ObjectList = (List<object>)JsonConvert.DeserializeObject(value);
            ObjectList = item;
            return Ok(ObjectList);

            // ObjectList = (List<object>)JsonConvert.DeserializeObject(value);
        }
    }
}