using Microsoft.Extensions.Logging;
using SalesApp.AppServices.Contracts;
using SalesApp.AppServices.Core;
using SalesApp.Infraestructure.Interfaces;

namespace SalesApp.AppServices.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductoDb _productDb;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductoDb productDb, ILogger<ProductService> logger)
        {
            this._productDb = productDb;
            this._logger = logger;
        }

        public async Task<ServiceResult> GetProductByCategory(int categoriaId)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = await this._productDb.GetProductByCategory(categoriaId);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los productos";
                this._logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
