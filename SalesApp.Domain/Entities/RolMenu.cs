
namespace SalesApp.Domain.Entities
{
    public class RolMenu : Core.AuditableEntity
    {
        public int? IdRol { get; set; } // FK
        public Rol? Rol { get; set; }
        public int? IdMenu { get; set; } // FK
        public Menu? Menu { get; set; }
    }
}
