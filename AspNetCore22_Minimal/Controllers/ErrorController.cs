using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCore22_Minimal.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("/Error/{statusCode}")]
        public IActionResult ErrorStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "404 error";
                    logger.LogWarning("404 error");
                    break;
                // ....
                default:
                    ViewBag.ErrorMessage = "Unknown error";
                    break;
            }
            return View("Error");
        }

        [HttpGet("/Error")]
        public IActionResult ErrorUnhandledException()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError(exceptionDetails.Error, "Error");
            return View("Error");
        }
    }
}