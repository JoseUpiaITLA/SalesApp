using Sales.UI.Web.Contract;
using Sales.UI.Web.Service;

namespace Sales.UI.Web
{
    public static class DependencyInjection
    {
        public static void AddServiceInjection(this IServiceCollection services)
        {
            services.AddTransient<INegocioService, NegocioService>();
            services.AddTransient<IVentaService, VentaService>();
            services.AddTransient<ITipoDocumentoVentaService, TipoDocumentoVentaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IDetalleVentaService, DetalleVentaService>();

        }
    }
}
