using Microsoft.Extensions.DependencyInjection;
using SalesApp.AppServices.Contracts;
using SalesApp.AppServices.Service;

namespace SalesApp.AppServices
{
    public static class DependencyInjection
    {
        public static void AddServicesDependency(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IVentaService, VentaService>();
        }
    }
}
