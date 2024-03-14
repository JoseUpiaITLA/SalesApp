using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;

namespace SalesApp.Infraestructure.Interfaces
{
    public interface INumeroCorrelativoDb : IDaoBase<NumeroCorrelativo, int>
    {
    }
}
