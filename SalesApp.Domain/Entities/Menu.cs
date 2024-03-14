
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Domain.Entities
{
    public class Menu : Core.AuditableEntity
    {
        public string? Descripcion { get; set; }
        [ForeignKey("MenuPadre")]
        public int? IdMenuPadre { get; set; }
        public Menu? MenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
    }
}
