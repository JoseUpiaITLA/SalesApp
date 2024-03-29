using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.Venta;
using SalesApp.Infraestructure.Models.Response;
using SalesApp.Infraestructure.Models.Negocio;
using System.Text.Json;
using System.Text;
using SalesApp.Infraestructure.Models.DetalleVenta;

namespace Sales.UI.Web.Service
{
    public class VentaService : IVentaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<VentaService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;
        public VentaService(IConfiguration configuration, ILogger<VentaService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = this._configuration["ApiConfig:BaseUrl"];
        }
        public async Task<ApiResponse<VentaBaseModel>> GetVentaById(int id)
        {
            ApiResponse<VentaBaseModel> result = new ApiResponse<VentaBaseModel>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Venta/GetVentaById?id={id}";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<VentaBaseModel>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error al conectarse al endpoint de GetVentaById";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obtenido de GerVentaById";
                this._logger.LogError(result.message, ex.ToString());
            }
            return result;
        }

        public async Task<ApiResponse<List<VentaBaseModel>>> GetVentas()
        {
            ApiResponse<List<VentaBaseModel>> result = new ApiResponse<List<VentaBaseModel>>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Venta/GetVentas";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<List<VentaBaseModel>>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error al conectarse al endpoint de GetVentas";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obtenido de GerVentas";
                this._logger.LogError(result.message, ex.ToString());
            }
            return result;
        }

        public async Task<ApiResponse<VentaUsuario>> GetVentasByUsuarioId(int usuarioId)
        {
            ApiResponse<VentaUsuario> result = new ApiResponse<VentaUsuario>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Venta/GetVentasByUsuarioId?usuarioId={usuarioId}";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<VentaUsuario>(resp);
                        }
                        else
                        {
                            result.success = false;
                            result.message = "Error al conectarse al endpoint de GetVentasByUsuarioId";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obtenido de GetVentasByUsuarioId";
                this._logger.LogError(result.message, ex.ToString());
            }
            return result;
        }

        public async Task<ApiResponse<VentaCreateModel>> PostVenta(VentaCreateModel ventaCreateModal)
        {
            ApiResponse<VentaCreateModel> result = new ApiResponse<VentaCreateModel>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{this._baseUrl}/Venta/Save";
                    StringContent content = new StringContent(JsonSerializer.Serialize(ventaCreateModal), Encoding.UTF8, "application/json");
                    string resp = string.Empty;

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result.data = JsonSerializer.Deserialize<ApiResponse<VentaCreateModel>>(resp).data;

                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result.data = JsonSerializer.Deserialize<ApiResponse<VentaCreateModel>>(resp).data;
                                return result;
                            }
                            else
                            {
                                result.success = false;
                                result.message = "Error conectandose al end point de Save Venta.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error guardando la venta.";
                this._logger.LogError(result.message, ex.ToString()); ;
            }
            return result;
        }
    }
}
