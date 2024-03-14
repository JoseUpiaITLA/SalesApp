using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.Configuracion;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly IConfiguracionDb _configuracionDb;
        public ConfiguracionController(IConfiguracionDb configuracionDb)
        {
            this._configuracionDb = configuracionDb;
        }

        [HttpGet("GetConfiguracions")]
        public IActionResult GetConfiguracions()
        {
            return Ok(this._configuracionDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(ConfiguracionBaseModal model)
        {
            DataResult result = this._configuracionDb.Save(new SalesApp.Domain.Entities.Configuracion
            {
                Recurso = model.Recurso,
                Propiedad = model.Propiedad,
                Valor = model.Valor,
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(ConfiguracionBaseModal model)
        {
            DataResult result = this._configuracionDb.Update(new SalesApp.Domain.Entities.Configuracion
            {
                Id = model.Id,
                Recurso = model.Recurso,
                Propiedad = model.Propiedad,
                Valor = model.Valor,
            });
            return Ok(result);
        }
    }
}
