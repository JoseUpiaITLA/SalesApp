
namespace SalesApp.Infraestructure.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
            SaveError(message);
        }
        void SaveError(string message)
        {
            // X logica para guardar el erro ocurrido //
        }
    }
}
