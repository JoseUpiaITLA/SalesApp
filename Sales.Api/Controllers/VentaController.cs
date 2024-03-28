using Microsoft.AspNetCore.Mvc;
using SalesApp.AppServices.Contracts;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
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

        [HttpGet("GetVentas")]
        public IActionResult GetVentas()
        {
            return Ok(this._ventaDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(VentaCreateModel model)
        {
            DataResult result = this._ventaDb.Save(new SalesApp.Domain.Entities.Venta
            {
                NumeroVenta = model.NumeroVenta,
                IdTipoDocumentoVenta = model.IdTipoDocumentoVenta,
                IdUsuario = model.IdUsuario,
                CocumentoCliente = model.CocumentoCliente,
                NombreCliente = model.NombreCliente,
                SubTotal = model.SubTotal,
                ImpuestoTotal = model.ImpuestoTotal,
                Total = model.Total,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(VentaBaseModel model)
        {
            DataResult result = this._ventaDb.Update(new SalesApp.Domain.Entities.Venta
            {
                Id = model.id,
                NumeroVenta = model.NumeroVenta,
                IdTipoDocumentoVenta = model.IdTipoDocumentoVenta,
                IdUsuario = model.IdUsuario,
                CocumentoCliente = model.CocumentoCliente,
                NombreCliente = model.NombreCliente,
                SubTotal = model.SubTotal,
                ImpuestoTotal = model.ImpuestoTotal,
                Total = model.Total
            });
            return Ok(result);
        }
    }
}
