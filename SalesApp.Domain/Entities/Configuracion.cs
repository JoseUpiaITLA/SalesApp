
using SalesApp.Domain.Core;

namespace SalesApp.Domain.Entities
{
    public class Configuracion : BaseEntity<short>
    {
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }        
    }
}
