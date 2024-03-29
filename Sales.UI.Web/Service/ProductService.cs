using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.Producto;
using SalesApp.Infraestructure.Models.Response;
using System.Text.Json;

namespace Sales.UI.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;

        public ProductService(IConfiguration configuration, ILogger<ProductService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = this._configuration["ApiConfig:BaseUrl"];
        }

        public async Task<ApiResponse<List<ProductoCategoria>>> GetProductByCategory(int categoriaId)
        {
            ApiResponse<List<ProductoCategoria>> result = new ApiResponse<List<ProductoCategoria>>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Producto/GetProductosByCategoria?categoriaId={categoriaId}";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<List<ProductoCategoria>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error al conectarse al endpoint de GetProductosByCategoria";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obtenido de GetProductosByCategoria";
                this._logger.LogError(result.message, ex.ToString());
            }
            return result;
        }
    }
}
