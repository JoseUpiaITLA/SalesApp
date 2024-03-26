
using Microsoft.Extensions.DependencyInjection;
using SalesApp.Infraestructure.Dao;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.Infraestructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructureDependency(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaDb, CategoriaDb>();
            services.AddTransient<IConfiguracionDb, ConfiguracionDb>();
            services.AddTransient<IDetalleVentaDb, DetalleVentaDb>();
            services.AddTransient<IMenuDb, MenuDb>();
            services.AddTransient<INegocioDb, NegocioDb>();
            services.AddTransient<INumeroCorrelativoDb, NumeroCorrelativoDb>();
            services.AddTransient<IProductoDb, ProductoDb>();
            services.AddTransient<IRolDb, RolDb>();
            services.AddTransient<IRolMenuDb, RolMenuDb>();
            services.AddTransient<ITipoDocumentoVentaDb, TipoDocumentoVentaDb>();
            services.AddTransient<IUsuarioDb, UsuarioDb>();
            services.AddTransient<IVentaDb, VentaDb>();
        }
    }
}
