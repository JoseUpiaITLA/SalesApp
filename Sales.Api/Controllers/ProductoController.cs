using Microsoft.AspNetCore.Mvc;
using SalesApp.AppServices.Contracts;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.Producto;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoDb _productoDb;
        private readonly IProductService _productoService;
        public ProductoController(IProductoDb productoDb, IProductService productoService)
        {
            this._productoDb = productoDb;
            this._productoService = productoService;
        }

        [HttpGet("GetProductos")]
        public IActionResult GetProductos()
        {
            return Ok(this._productoDb.GetAll());
        }

        [HttpGet("GetProductosByCategoria")]
        public async Task<IActionResult> GetProductsByCategoria(int categoriaId)
        {
            var result = await this._productoService.GetProductByCategory(categoriaId);
            
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
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
                Id = model.id,
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
