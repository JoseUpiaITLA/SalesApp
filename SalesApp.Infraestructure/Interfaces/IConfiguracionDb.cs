using SalesApp.Domain.Entities;
using SalesApp.Infraestructure.Core;

namespace SalesApp.Infraestructure.Interfaces
{
    public interface IConfiguracionDb : IDaoBase<Configuracion, short>
    {
    }
}
