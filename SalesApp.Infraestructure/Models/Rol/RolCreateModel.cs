﻿namespace SalesApp.Infraestructure.Models.Rol
{
    public class RolCreateModel : RolBaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
