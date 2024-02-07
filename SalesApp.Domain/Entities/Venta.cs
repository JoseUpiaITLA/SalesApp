
namespace SalesApp.Domain.Entities
{
    public class Venta : Core.BaseEntity
    {
        public string? NumeroVenta { get; set; }
        public int? IdTipoDocumentoVenta { get; set; } // FK
        public TipoDocumentoVenta? TipoDocumentoVenta { get; set; }
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
