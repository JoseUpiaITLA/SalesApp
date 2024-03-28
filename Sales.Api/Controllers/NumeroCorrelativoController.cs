using Microsoft.AspNetCore.Mvc;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.NumeroCorrelativo;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroCorrelativoController : ControllerBase
    {
        private readonly INumeroCorrelativoDb _numeroCorrelativoDb;
        public NumeroCorrelativoController(INumeroCorrelativoDb numeroCorrelativoDb)
        {
            this._numeroCorrelativoDb = numeroCorrelativoDb;
        }

        [HttpGet("GetNumeroCorrelativos")]
        public IActionResult GetNumeroCorrelativos()
        {
            return Ok(this._numeroCorrelativoDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(NumeroCorrelativoBaseModel model)
        {
            DataResult result = this._numeroCorrelativoDb.Save(new SalesApp.Domain.Entities.NumeroCorrelativo
            {
                UltimoNumero = model.UltimoNumero,
                CantidadDigitos = model.CantidadDigitos,
                Gestion = model.Gestion,
                FechaActualizacion = model.FechaActualizacion,
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(NumeroCorrelativoBaseModel model)
        {
            DataResult result = this._numeroCorrelativoDb.Update(new SalesApp.Domain.Entities.NumeroCorrelativo
            {
                Id = model.id,
                UltimoNumero = model.UltimoNumero,
                CantidadDigitos = model.CantidadDigitos,
                Gestion = model.Gestion,
                FechaActualizacion = model.FechaActualizacion
            });
            return Ok(result);
        }
    }
}
