﻿namespace Sales.Api.Models.Rol
{
    public class RolUpdateModel : RolBaseModel
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
