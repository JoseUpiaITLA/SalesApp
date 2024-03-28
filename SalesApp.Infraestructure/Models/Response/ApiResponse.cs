
namespace SalesApp.Infraestructure.Models.Response
{
    public class ApiResponse<TModel>
    {
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public TModel? Data { get; set; }
    }
}
