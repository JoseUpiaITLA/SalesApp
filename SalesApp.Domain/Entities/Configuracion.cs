
namespace SalesApp.Domain.Entities
{
    public class Configuracion : Core.BaseEntity
    {
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }        
    }
}
