using Microsoft.AspNetCore.Mvc;
using Sales.UI.Web.Contract;
using Sales.UI.Web.Models;
using SalesApp.Infraestructure.Models.Venta;

namespace Sales.UI.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService _ventaService;
        private readonly ITipoDocumentoVentaService _tipoDocumentoVentaService;
        private readonly IProductService _productService;
        private readonly ICategoriaService _categoriaService;
        private readonly IDetalleVentaService _detalleVentaService;

        public VentaController(IVentaService ventaService, ITipoDocumentoVentaService tipoDocumentoVentaService, IProductService productService, ICategoriaService categoriaService, IDetalleVentaService detalleVentaService)
        {
            _ventaService = ventaService;
            _tipoDocumentoVentaService = tipoDocumentoVentaService;
            _productService = productService;
            _categoriaService = categoriaService;
            _detalleVentaService = detalleVentaService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await this._ventaService.GetVentas();

            if (!result.success)
            {
                ViewBag.Message = result.message;
                return View();
            }

            List<VentaBaseModel> listNegocios = result.data;
            return View(listNegocios);
        }

        public async Task<IActionResult> Create()
        {
            var resultTipoDocumentoVenta = await this._tipoDocumentoVentaService.GetTipoDocumentoVentas();
            var resultCategoria = await this._categoriaService.GetCategorias();

            CreateVentaModel createVenta = new CreateVentaModel();
            createVenta.TipoDocumentoVenta = resultTipoDocumentoVenta.data;
            createVenta.Categoria = resultCategoria.data;

            return View(createVenta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVentaModel createVenta)
        {
            createVenta.Venta.idUsuarioCreacion = 1;
            createVenta.Venta.idUsuario = 1;
            createVenta.Venta.fechaRegistro = DateTime.Now;

            var resultSaveVenta = await _ventaService.PostVenta(createVenta.Venta);
            if (resultSaveVenta.success)
            {
                createVenta.DetalleVenta.IdVenta = resultSaveVenta.data.id;
            }
            var resultSaveDetalleVenta = await _detalleVentaService.PostDetalleVenta(createVenta.DetalleVenta);

            if (!resultSaveVenta.success)
            {
                ViewBag.Message = resultSaveVenta.message;
                return View();
            }

            if (!resultSaveDetalleVenta.success)
            {
                ViewBag.Message = resultSaveDetalleVenta.message;
                return View();
            }

            return Redirect("~/Venta/Index");
        }

        public IActionResult Details()
        {
            return View();
        }


    }
}
