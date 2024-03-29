using Microsoft.AspNetCore.Mvc;
using SalesApp.AppServices.Contracts;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.Venta;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaDb _ventaDb;
        private readonly IVentaService _ventaService;
        public VentaController(IVentaDb ventaDb, IVentaService ventaService)
        {
            this._ventaDb = ventaDb;
            this._ventaService = ventaService;
        }

        [HttpGet("GetVentasByUsuarioId")]
        public async Task<IActionResult> GetVentasByUsuarioId(int usuarioId)
        {
            var result = await this._ventaService.GetVentasByUsuario(usuarioId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetVentaById")]
        public IActionResult GetVentas(int id)
        {
            return Ok(this._ventaDb.GetById(id));
        }

        [HttpGet("GetVentas")]
        public IActionResult GetVentas()
        {
            return Ok(this._ventaDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(VentaCreateModel model)
        {
            ApiResponse<SalesApp.Domain.Entities.Venta> result = this._ventaDb.SaveVenta(new SalesApp.Domain.Entities.Venta
            {
                NumeroVenta = model.numeroVenta,
                IdTipoDocumentoVenta = model.idTipoDocumentoVenta,
                IdUsuario = model.idUsuario,
                CocumentoCliente = model.cocumentoCliente,
                NombreCliente = model.nombreCliente,
                SubTotal = model.subTotal,
                ImpuestoTotal = model.impuestoTotal,
                Total = model.total,
                FechaRegistro = model.fechaRegistro,
                IdUsuarioCreacion = model.idUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(VentaBaseModel model)
        {
            DataResult result = this._ventaDb.Update(new SalesApp.Domain.Entities.Venta
            {
                Id = model.id,
                NumeroVenta = model.numeroVenta,
                IdTipoDocumentoVenta = model.idTipoDocumentoVenta,
                IdUsuario = model.idUsuario,
                CocumentoCliente = model.cocumentoCliente,
                NombreCliente = model.nombreCliente,
                SubTotal = model.subTotal,
                ImpuestoTotal = model.impuestoTotal,
                Total = model.total
            });
            return Ok(result);
        }
    }
}
