﻿namespace Sales.Api.Models.TipoDocumentoVenta
{
    public class TipoDocumentoVentaBaseModel : BaseModel
    {
        public string? Descripcion { get; set; }
        public bool EsActivo { get; set; }
    }
}
