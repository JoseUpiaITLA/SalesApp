﻿namespace SalesApp.Infraestructure.Models.TipoDocumentoVenta
{
    public class TipoDocumentoVentaCreateModel : TipoDocumentoVentaBaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
