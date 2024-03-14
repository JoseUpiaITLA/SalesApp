
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesApp.Domain.Entities
{
    public class Venta : Core.BaseEntity<int>
    {
        public string? NumeroVenta { get; set; }
        [ForeignKey("TipoDocumentoVenta")]
        public int? IdTipoDocumentoVenta { get; set; } // FK
        public TipoDocumentoVenta? TipoDocumentoVenta { get; set; }
        [ForeignKey("Usuario")]
        public int? IdUsuario { get; set; } // FK
        public Usuario? Usuario { get; set; }
        public string? CocumentoCliente { get; set; }
        public string? NombreCliente { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? ImpuestoTotal { get; set; }
        public decimal? Total { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
