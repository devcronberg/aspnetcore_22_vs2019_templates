using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCore22_Minimal.Controllers
{
    public class AppController : Controller
    {
        private readonly ILogger logger;
        private readonly IConfiguration config;

        public AppController(ILogger<AppController> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
        }

        [HttpGet("~/")]
        public IActionResult Index()
        {
            logger.LogInformation("My log message");
            ViewBag.Header = config["Settings:Header"];
            return View();
        }

        [HttpGet("~/TestError")]
        public IActionResult TestError()
        {
            throw new ApplicationException("Test error");            
        }
    }
}