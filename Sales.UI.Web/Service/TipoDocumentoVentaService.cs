using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.TipoDocumentoVenta;
using System.Text.Json;

namespace Sales.UI.Web.Service
{
    public class TipoDocumentoVentaService : ITipoDocumentoVentaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TipoDocumentoVentaService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;

        public TipoDocumentoVentaService(IConfiguration configuration, ILogger<TipoDocumentoVentaService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = this._configuration["ApiConfig:BaseUrl"];
        }

        public async Task<ApiResponse<List<TipoDocumentoVentaBaseModel>>> GetTipoDocumentoVentas()
        {
            ApiResponse<List<TipoDocumentoVentaBaseModel>> result = new ApiResponse<List<TipoDocumentoVentaBaseModel>>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/TipoDocumentoVenta/GetTipoDocumentoVentas";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<List<TipoDocumentoVentaBaseModel>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error al conectarse al endpoint de GetTipoDocumentoVentas";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obtenido de GetTipoDocumentoVentas";
                this._logger.LogError(result.message, ex.ToString());
            }
            return result;
        }
    }
}
