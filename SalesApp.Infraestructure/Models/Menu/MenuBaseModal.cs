namespace SalesApp.Infraestructure.Models.Menu
{
    public class MenuBaseModal : BaseModel
    {
        public string? Descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }
        public bool EsActivo { get; set; }
    }
}
