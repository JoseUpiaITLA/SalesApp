﻿namespace SalesApp.Infraestructure.Models.TipoDocumentoVenta
{
    public class TipoDocumentoVentaUpdateModel : TipoDocumentoVentaBaseModel
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
