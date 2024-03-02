using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.Categoria;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaDb _categoriaDb;
        public CategoriaController(ICategoriaDb categoriaDb)
        {
            this._categoriaDb = categoriaDb;
        }

        [HttpGet("GetCategorias")]
        public IActionResult GetCategorias()
        {
            return Ok(this._categoriaDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(CategoriaCreateModel createModel)
        {
            DataResult result = this._categoriaDb.Save(new SalesApp.Domain.Entities.Categoria
            { 
                Descripcion = createModel.Descripcion,
                EsActivo = createModel.EsActivo,
                FechaRegistro = createModel.FechaRegistro,
                IdUsuarioCreacion = createModel.IdUsuarioCreacion,
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoriaUpdateModel updateModel)
        {
            DataResult result = this._categoriaDb.Update(new SalesApp.Domain.Entities.Categoria
            {
                Descripcion = updateModel.Descripcion,
                EsActivo = updateModel.EsActivo,
                FechaMod = updateModel.FechaMod,
                IdUsuarioMod = updateModel.IdUsuarioMod,
                IdUsuarioElimino = updateModel.IdUsuarioElimino,
                FechaElimino = updateModel.FechaElimino,
                Eliminado = updateModel.Eliminado,
            });
            return Ok(result);
        }
    }
}
