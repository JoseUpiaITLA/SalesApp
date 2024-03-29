using Microsoft.AspNetCore.Mvc;
using SalesApp.Infraestructure.Core;
using SalesApp.Infraestructure.Interfaces;
using SalesApp.Infraestructure.Models.TipoDocumentoVenta;

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
                Descripcion = model.descripcion,
                EsActivo = model.esActivo,
                FechaRegistro = model.fechaRegistro,
                IdUsuarioCreacion = model.idUsuarioCreacion
            });
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(TipoDocumentoVentaUpdateModel model)
        {
            DataResult result = this._tipoDocumentoVentaDb.Update(new SalesApp.Domain.Entities.TipoDocumentoVenta
            {
                Id = model.id,
                Descripcion = model.descripcion,
                EsActivo = model.esActivo,
                FechaMod = model.fechaMod,
                IdUsuarioMod = model.idUsuarioMod
            });
            return Ok(result);
        }
    }
}
