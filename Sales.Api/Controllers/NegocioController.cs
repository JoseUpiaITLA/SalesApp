using Microsoft.AspNetCore.Mvc;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.Negocio;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioDb _negocioDb;
        public NegocioController(INegocioDb negocioDb)
        {
            this._negocioDb = negocioDb;
        }

        [HttpGet("GetNegocios")]
        public IActionResult GetNegocios()
        {
            return Ok(this._negocioDb.GetAll());
        }

        [HttpGet("GetNegocioById")]
        public IActionResult GetNegocioById(int id)
        {
            return Ok(this._negocioDb.GetById(id));
        }

        [HttpPost("Save")]
        public IActionResult Save(NegocioCreateModal model)
        {
            DataResult result = this._negocioDb.Save(new SalesApp.Domain.Entities.Negocio
            {
                UrlLogo = model.urlLogo,
                NombreLogo = model.nombreLogo,
                NumeroDocumento = model.numeroDocumento,
                Nombre = model.nombre,
                Correo = model.correo,
                Direccion = model.direccion,
                Telefono = model.telefono,
                PorcentajeImpuesto = model.porcentajeImpuesto,
                SimboloMoneda = model.simboloMoneda,
                IdUsuarioCreacion = model.IdUsuarioCreacion,
                FechaRegistro = model.FechaRegistro
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(NegocioUpdateModal model)
        {
            DataResult result = this._negocioDb.Update(new SalesApp.Domain.Entities.Negocio
            {
                Id = model.id,
                UrlLogo = model.urlLogo,
                NombreLogo = model.nombreLogo,
                NumeroDocumento = model.numeroDocumento,
                Nombre = model.nombre,
                Correo = model.correo,
                Direccion = model.direccion,
                Telefono = model.telefono,
                PorcentajeImpuesto = model.porcentajeImpuesto,
                SimboloMoneda = model.simboloMoneda,
                IdUsuarioMod = model.IdUsuarioMod,
                FechaMod = model.FechaMod
            });
            return Ok(result);
        }
    }
}
