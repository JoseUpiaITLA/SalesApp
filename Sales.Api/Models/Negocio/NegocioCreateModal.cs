﻿namespace Sales.Api.Models.Negocio
{
    public class NegocioCreateModal : NegocioBaseModal
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
