﻿namespace Sales.Api.Models.Menu
{
    public class MenuCreateModal : MenuBaseModal
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
