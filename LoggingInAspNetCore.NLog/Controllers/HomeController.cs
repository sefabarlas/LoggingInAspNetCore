using LoggingInAspNetCore.NLog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingInAspNetCore.NLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }

        public IActionResult Index()
        {
            try
            {
                int value = 5;
                int value2 = 0;

                var result = value / value2;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}