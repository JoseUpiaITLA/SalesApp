using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.Venta;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaDb _ventaDb;
        public VentaController(IVentaDb ventaDb)
        {
            this._ventaDb = ventaDb;
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
                Id = model.Id,
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
