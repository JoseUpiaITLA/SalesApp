using Microsoft.AspNetCore.Mvc;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.Usuario;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioDb _usuarioDb;
        public UsuarioController(IUsuarioDb usuarioDb)
        {
            this._usuarioDb = usuarioDb;
        }

        [HttpGet("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            return Ok(this._usuarioDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(UsuarioCreateModel model)
        {
            DataResult result = this._usuarioDb.Save(new SalesApp.Domain.Entities.Usuario
            {
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                IdRol = model.IdRol,
                UrlFoto = model.UrlFoto,
                NombreFoto = model.NombreFoto,
                Clave = model.Clave,
                EsActivo = model.EsActivo,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(UsuarioUpdateModel model)
        {
            DataResult result = this._usuarioDb.Update(new SalesApp.Domain.Entities.Usuario
            {
                Id = model.id,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Telefono = model.Telefono,
                IdRol = model.IdRol,
                UrlFoto = model.UrlFoto,
                NombreFoto = model.NombreFoto,
                Clave = model.Clave,
                EsActivo = model.EsActivo,
                FechaMod = model.FechaMod,
                IdUsuarioMod = model.IdUsuarioMod
            });
            return Ok(result);
        }
    }
}
