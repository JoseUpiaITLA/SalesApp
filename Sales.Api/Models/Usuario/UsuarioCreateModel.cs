﻿namespace Sales.Api.Models.Usuario
{
    public class UsuarioCreateModel : UsuarioBaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
