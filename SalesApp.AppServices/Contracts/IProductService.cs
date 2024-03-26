using SalesApp.AppServices.Core;

namespace SalesApp.AppServices.Contracts
{
    public interface IProductService
    {
        Task<ServiceResult> GetProductByCategory(int categoriaId);
    }
}
