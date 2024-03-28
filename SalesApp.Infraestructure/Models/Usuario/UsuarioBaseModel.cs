﻿namespace  SalesApp.Infraestructure.Models.Usuario
{
    public class UsuarioBaseModel : BaseModel
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdRol { get; set; }
        public string? UrlFoto { get; set; }
        public string? NombreFoto { get; set; }
        public string? Clave { get; set; }
        public bool EsActivo { get; set; }
    }
}
