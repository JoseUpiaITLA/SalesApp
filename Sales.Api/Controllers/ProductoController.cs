using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.Producto;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoDb _productoDb;
        public ProductoController(IProductoDb productoDb)
        {
            this._productoDb = productoDb;
        }

        [HttpGet("GetProductos")]
        public IActionResult GetProductos()
        {
            return Ok(this._productoDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(ProductoCreateModel model)
        {
            DataResult result = this._productoDb.Save(new SalesApp.Domain.Entities.Producto
            {
                CodigoBarra = model.CodigoBarra,
                Marca = model.Marca,
                Descripcion = model.Descripcion,
                IdCategoria = model.IdCategoria,
                Stock = model.Stock,
                UrlImagen = model.UrlImagen,
                NombreImagen = model.NombreImagen,
                Precio = model.Precio,
                EsActivo = model.EsActivo,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(ProductoUpdateModel model)
        {
            DataResult result = this._productoDb.Update(new SalesApp.Domain.Entities.Producto
            {
                Id = model.Id,
                CodigoBarra = model.CodigoBarra,
                Marca = model.Marca,
                Descripcion = model.Descripcion,
                IdCategoria = model.IdCategoria,
                Stock = model.Stock,
                UrlImagen = model.UrlImagen,
                NombreImagen = model.NombreImagen,
                Precio = model.Precio,
                EsActivo = model.EsActivo,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            });
            return Ok(result);
        }
    }
}
