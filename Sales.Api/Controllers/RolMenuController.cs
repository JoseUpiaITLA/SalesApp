using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.RolMenu;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolMenuController : ControllerBase
    {
        private readonly IRolMenuDb _rolMenuDb;
        public RolMenuController(IRolMenuDb rolMenuDb)
        {
            this._rolMenuDb = rolMenuDb;
        }

        [HttpGet("GetRolMenus")]
        public IActionResult GetRolMenus()
        {
            return Ok(this._rolMenuDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(RolMenuCreateModel model)
        {
            DataResult result = this._rolMenuDb.Save(new SalesApp.Domain.Entities.RolMenu
            {
                IdRol = model.Id,
                IdMenu = model.IdMenu,
                EsActivo = model.EsActivo,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(RolMenuUpdateModel model)
        {
            DataResult result = this._rolMenuDb.Update(new SalesApp.Domain.Entities.RolMenu
            {
                Id = model.Id,
                IdRol = model.IdRol,
                IdMenu = model.IdMenu,
                EsActivo = model.EsActivo,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            });
            return Ok(result);
        }
    }
}
