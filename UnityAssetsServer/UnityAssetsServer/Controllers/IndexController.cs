using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnityAssetsServer.Controllers {
    public class IndexController : ControllerBase {
        
        [Route("")]
        [HttpGet]
        public IActionResult Index() {
            return Redirect("/swagger/index.html");
        }
    }
}
