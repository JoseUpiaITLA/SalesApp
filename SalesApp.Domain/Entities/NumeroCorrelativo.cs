
using SalesApp.Domain.Core;

namespace SalesApp.Domain.Entities
{
    public class NumeroCorrelativo : BaseEntity<int>
    {
        public int? UltimoNumero { get; set; }
        public int? CantidadDigitos { get; set; }
        public string? Gestion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
