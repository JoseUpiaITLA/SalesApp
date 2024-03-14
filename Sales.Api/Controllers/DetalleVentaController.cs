using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.DetalleVenta;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaDb _detalleVentaDb;
        public DetalleVentaController(IDetalleVentaDb detalleVentaDb)
        {
            this._detalleVentaDb = detalleVentaDb;
        }

        [HttpGet("GetDetalleVentas")]
        public IActionResult GetDetalleVentas()
        {
            return Ok(this._detalleVentaDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(DetalleVentaBaseModal model)
        {
            DataResult result = this._detalleVentaDb.Save(new SalesApp.Domain.Entities.DetalleVenta
            {
                IdVenta = model.IdVenta,
                IdProducto = model.IdProducto,
                MarcaProducto = model.MarcaProducto,
                DescripcionProducto = model.DescripcionProducto,
                CategoriaProducto = model.CategoriaProducto,
                Cantidad = model.Cantidad,
                Precio = model.Precio,
                Total = model.Total
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(DetalleVentaBaseModal model)
        {
            DataResult result = this._detalleVentaDb.Update(new SalesApp.Domain.Entities.DetalleVenta
            {
                Id = model.Id,
                IdVenta = model.IdVenta,
                IdProducto = model.IdProducto,
                MarcaProducto = model.MarcaProducto,
                DescripcionProducto = model.DescripcionProducto,
                CategoriaProducto = model.CategoriaProducto,
                Cantidad = model.Cantidad,
                Precio = model.Precio,
                Total = model.Total
            });
            return Ok(result);
        }
    }
}
