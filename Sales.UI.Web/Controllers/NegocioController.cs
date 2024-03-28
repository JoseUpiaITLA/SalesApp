using Microsoft.AspNetCore.Mvc;
using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.Negocio;

namespace Sales.UI.Web.Controllers
{
    public class NegocioController : Controller
    {
        private readonly INegocioService _negocioService;

        public NegocioController(INegocioService negocioService)
        {
            _negocioService = negocioService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._negocioService.GetNegocios();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            List<NegocioBaseModal> listNegocios = result.Data;
            return View(listNegocios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NegocioCreateModal negocioCreateModal)
        {
            negocioCreateModal.IdUsuarioCreacion = 1;
            negocioCreateModal.FechaRegistro = DateTime.Now;

            var result = await _negocioService.PostNegocio(negocioCreateModal);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return Redirect("~/Negocio/Index");
        }

        public IActionResult Details()
        {
            return View();
        }

        public async Task<IActionResult> Edict(int id)
        {
            var result = await _negocioService.GetNegocioById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            NegocioBaseModal listNegocios = result.Data;
            return View(listNegocios);
        }

        [HttpPost]
        public async Task<IActionResult> Edict(NegocioUpdateModal negocioUpdateModal)
        {
            negocioUpdateModal.IdUsuarioMod = 1;
            negocioUpdateModal.FechaMod = DateTime.Now;

            var result = await _negocioService.PutNegocio(negocioUpdateModal);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return Redirect("~/Negocio/Index");
        }


    }
}
