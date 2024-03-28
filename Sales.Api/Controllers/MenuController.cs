using Microsoft.AspNetCore.Mvc;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.Menu;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuDb _menuDb;
        public MenuController(IMenuDb menuDb)
        {
            this._menuDb = menuDb;
        }

        [HttpGet("GetMenus")]
        public IActionResult GetMenus()
        {
            return Ok(this._menuDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(MenuCreateModal model)
        {
            DataResult result = this._menuDb.Save(new SalesApp.Domain.Entities.Menu
            {
                Descripcion = model.Descripcion,
                IdMenuPadre = model.IdMenuPadre,
                Icono = model.Icono,
                Controlador = model.Controlador,
                PaginaAccion = model.PaginaAccion,
                EsActivo = model.EsActivo,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(MenuUpdateModal model)
        {
            DataResult result = this._menuDb.Update(new SalesApp.Domain.Entities.Menu
            {
                Id = model.id,
                Descripcion = model.Descripcion,
                IdMenuPadre = model.IdMenuPadre,
                Icono = model.Icono,
                Controlador = model.Controlador,
                PaginaAccion = model.PaginaAccion,
                EsActivo = model.EsActivo,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            });
            return Ok(result);
        }
    }
}
