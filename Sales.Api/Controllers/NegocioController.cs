using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.Negocio;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

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

        [HttpPost("Save")]
        public IActionResult Save(NegocioCreateModal model)
        {
            DataResult result = this._negocioDb.Save(new SalesApp.Domain.Entities.Negocio
            {
                UrlLogo = model.UrlLogo,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda,
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
                Id = model.Id,
                UrlLogo = model.UrlLogo,
                NombreLogo = model.NombreLogo,
                NumeroDocumento = model.NumeroDocumento,
                Nombre = model.Nombre,
                Correo = model.Correo,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                PorcentajeImpuesto = model.PorcentajeImpuesto,
                SimboloMoneda = model.SimboloMoneda,
                IdUsuarioMod = model.IdUsuarioMod,
                FechaMod = model.FechaMod
            });
            return Ok(result);
        }
    }
}
