using Microsoft.EntityFrameworkCore;
using SalesApp.Domain.Entities;

namespace SalesApp.Infraestructure.Context
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base (options)
        {
                        
        }

        #region "DbSet"
        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Configuracion>? Configuracion { get; set; }
        public DbSet<DetalleVenta>? DetalleVenta { get; set; }
        public DbSet<Menu>? Menu { get; set; }
        public DbSet<Negocio>? Negocio { get; set; }
        public DbSet<NumeroCorrelativo>? NumeroCorrelativo { get; set; }
        public DbSet<Producto>? Producto { get; set; }
        public DbSet<Rol>? Rol { get; set; }
        public DbSet<RolMenu>? RolMenu { get; set; }
        public DbSet<TipoDocumentoVenta>? TipoDocumentoVenta { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<Venta>? Venta { get; set; }
        #endregion
    }
}
