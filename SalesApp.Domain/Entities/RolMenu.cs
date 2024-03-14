using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Domain.Entities
{
    public class RolMenu : Core.AuditableEntity
    {
        [ForeignKey("Rol")]
        public int? IdRol { get; set; }
        public Rol? Rol { get; set; }
        [ForeignKey("Menu")]
        public int? IdMenu { get; set; }
        public Menu? Menu { get; set; }
    }
}
