using Fiap.Web.Challenge.Logging;
using Fiap.Web.Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLogger _customLogger;

        public HomeController(ICustomLogger customLogger)
        {
            _customLogger = customLogger;
        }

        public IActionResult Index()
        {
            _customLogger.Log("Acessou a Home");
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
