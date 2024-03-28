using Microsoft.AspNetCore.Mvc;

namespace Sales.UI.Web.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
