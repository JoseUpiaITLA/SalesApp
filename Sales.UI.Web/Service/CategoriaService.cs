using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.Categoria;
using SalesApp.Infraestructure.Models.Response;
using System.Text.Json;

namespace Sales.UI.Web.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CategoriaService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;

        public CategoriaService(IConfiguration configuration, ILogger<CategoriaService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = this._configuration["ApiConfig:BaseUrl"];
        }

        public async Task<ApiResponse<List<CategoriaBaseModal>>> GetCategorias()
        {
            ApiResponse<List<CategoriaBaseModal>> result = new ApiResponse<List<CategoriaBaseModal>>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Categoria/GetCategorias";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<List<CategoriaBaseModal>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error al conectarse al endpoint de GetCategorias";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obtenido de GetCategorias";
                this._logger.LogError(result.message, ex.ToString());
            }
            return result;
        }
    }
}
