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

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            List<NegocioBaseModal> listNegocios = result.data;
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
            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return Redirect("~/Negocio/Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _negocioService.GetNegocioById(id);
            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            NegocioBaseModal negocioBaseModal = result.data;
            return View(negocioBaseModal);

        }

        public async Task<IActionResult> Edict(int id)
        {
            var result = await _negocioService.GetNegocioById(id);

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            NegocioBaseModal listNegocios = result.data;
            return View(listNegocios);
        }

        [HttpPost]
        public async Task<IActionResult> Edict(NegocioUpdateModal negocioUpdateModal)
        {
            negocioUpdateModal.IdUsuarioMod = 1;
            negocioUpdateModal.FechaMod = DateTime.Now;

            var result = await _negocioService.PutNegocio(negocioUpdateModal);
            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            return Redirect("~/Negocio/Index");
        }


    }
}
