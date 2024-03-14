
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Domain.Entities
{
    public class Usuario : Core.AuditableEntity
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        [ForeignKey("Rol")]
        public int? IdRol { get; set; } // FK
        public Rol? Rol { get; set; }
        public string? UrlFoto { get; set; }
        public string? NombreFoto { get; set; }
        public string? Clave { get; set; }
    }
}
