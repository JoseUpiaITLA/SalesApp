using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models.TipoDocumentoVenta;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoVentaController : ControllerBase
    {
        private readonly ITipoDocumentoVentaDb _tipoDocumentoVentaDb;
        public TipoDocumentoVentaController(ITipoDocumentoVentaDb tipoDocumentoVentaDb)
        {
            this._tipoDocumentoVentaDb = tipoDocumentoVentaDb;
        }

        [HttpGet("GetTipoDocumentoVentas")]
        public IActionResult GetTipoDocumentoVentas()
        {
            return Ok(this._tipoDocumentoVentaDb.GetAll());
        }

        [HttpPost("Save")]
        public IActionResult Save(TipoDocumentoVentaCreateModel model)
        {
            DataResult result = this._tipoDocumentoVentaDb.Save(new SalesApp.Domain.Entities.TipoDocumentoVenta
            {
                Descripcion = model.Descripcion,
                EsActivo = model.EsActivo,
                FechaRegistro = model.FechaRegistro,
                IdUsuarioCreacion = model.IdUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(TipoDocumentoVentaUpdateModel model)
        {
            DataResult result = this._tipoDocumentoVentaDb.Update(new SalesApp.Domain.Entities.TipoDocumentoVenta
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
