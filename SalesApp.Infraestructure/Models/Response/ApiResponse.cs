
namespace SalesApp.Infraestructure.Models.Response
{
    public class ApiResponse<TModel>
    {
        public string? message { get; set; }
        public bool success { get; set; } = true;
        public TModel? data { get; set; }
    }
}
