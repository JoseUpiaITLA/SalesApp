using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.Rol;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolDb _rolDb;
        public RolController(IRolDb rolDb)
        {
            this._rolDb = rolDb;
        }

        [HttpGet("GetRols")]
        public IActionResult GetRols()
        {
            return Ok(this._rolDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(RolCreateModel model)
        {
            DataResult result = this._rolDb.Save(new SalesApp.Domain.Entities.Rol
            {
                Descripcion = model.Descripcion,
                EsActivo = model.EsActivo,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(RolUpdateModel model)
        {
            DataResult result = this._rolDb.Update(new SalesApp.Domain.Entities.Rol
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                EsActivo = model.EsActivo,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            });
            return Ok(result);
        }
    }
}
