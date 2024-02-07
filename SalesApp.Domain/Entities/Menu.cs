
namespace SalesApp.Domain.Entities
{
    public class Menu : Core.AuditableEntity
    {
        public string? Descripcion { get; set; }
        public int? IdMenuPadre { get; set; } // FK
        public Menu? MenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
    }
}
