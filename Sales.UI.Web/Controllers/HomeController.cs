using Microsoft.AspNetCore.Mvc;
using Sales.UI.Web.Contract;
using Sales.UI.Web.Models;
using System.Diagnostics;

namespace Sales.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INegocioService _negocioService;

        public HomeController(ILogger<HomeController> logger, INegocioService negocioService)
        {
            _logger = logger;
            _negocioService = negocioService;
        }

        public async Task<IActionResult> Index()
       {
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