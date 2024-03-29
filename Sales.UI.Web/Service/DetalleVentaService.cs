using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.DetalleVenta;
using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.Venta;
using System.Text;
using System.Text.Json;

namespace Sales.UI.Web.Service
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DetalleVentaService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;

        public DetalleVentaService(IConfiguration configuration, ILogger<DetalleVentaService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = this._configuration["ApiConfig:BaseUrl"];
        }

        public async Task<ApiResponse<DetalleVentaBaseModal>> PostDetalleVenta(DetalleVentaBaseModal detalleVentaModal)
        {
            ApiResponse<DetalleVentaBaseModal> result = new ApiResponse<DetalleVentaBaseModal>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{this._baseUrl}/DetalleVenta/Save";
                    StringContent content = new StringContent(JsonSerializer.Serialize(detalleVentaModal), Encoding.UTF8, "application/json");
                    string resp = string.Empty;

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<DetalleVentaBaseModal>(resp);

                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result.data = JsonSerializer.Deserialize<DetalleVentaBaseModal>(resp);
                                return result;
                            }
                            else
                            {
                                result.success = false;
                                result.message = "Error conectandose al endpoint de Save DetalleVenta.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error guardando el DetalleVenta.";
                this._logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }
    }
}
