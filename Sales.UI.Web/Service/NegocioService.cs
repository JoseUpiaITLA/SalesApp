using Sales.UI.Web.Contract;
using SalesApp.Infraestructure.Models.Negocio;
using SalesApp.Infraestructure.Models.Response;
using System.Text;
using System.Text.Json;

namespace Sales.UI.Web.Service
{
    public class NegocioService : INegocioService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<NegocioService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseUrl;
        public NegocioService(IConfiguration configuration, ILogger<NegocioService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _baseUrl = this._configuration["ApiConfig:BaseUrl"];
        }

        public async Task<ApiResponse<NegocioBaseModal>> GetNegocioById(int id)
        {
            ApiResponse<NegocioBaseModal> result = new ApiResponse<NegocioBaseModal>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Negocio/GetNegocioById?id={id}";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.Data = JsonSerializer.Deserialize<NegocioBaseModal>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error al conectarse al endpoint de GetNegocioById";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtenido de GerNegocios";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<ApiResponse<List<NegocioBaseModal>>> GetNegocios()
        {
            ApiResponse<List<NegocioBaseModal>> result = new ApiResponse<List<NegocioBaseModal>>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{_baseUrl}/Negocio/GetNegocios";
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            result.Data = JsonSerializer.Deserialize<List<NegocioBaseModal>>(resp);
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Error al conectarse al endpoint de GetNegocios";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obtenido de GerNegocios";
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public async Task<ApiResponse<NegocioCreateModal>> PostNegocio(NegocioCreateModal negocioCreateModal)
        {
            ApiResponse<NegocioCreateModal> result = new ApiResponse<NegocioCreateModal>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{this._baseUrl}/Negocio/Save";
                    StringContent content = new StringContent(JsonSerializer.Serialize(negocioCreateModal), Encoding.UTF8, "application/json");
                    string resp = string.Empty;

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result.Data = JsonSerializer.Deserialize<NegocioCreateModal>(resp);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result.Data = JsonSerializer.Deserialize<NegocioCreateModal>(resp);
                                return result;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "Error conectandose al end point de Save Negocio.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el negocio.";
                this._logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

        public async Task<ApiResponse<NegocioUpdateModal>> PutNegocio(NegocioUpdateModal negocioUpdateModal)
        {
            ApiResponse<NegocioUpdateModal> result = new ApiResponse<NegocioUpdateModal>();
            try
            {
                using (var httpClient = this._httpClientFactory.CreateClient())
                {
                    var url = $"{this._baseUrl}/Negocio/Update";
                    StringContent content = new StringContent(JsonSerializer.Serialize(negocioUpdateModal), Encoding.UTF8, "application/json");
                    string resp = string.Empty;

                    using (var response = await httpClient.PutAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resp = await response.Content.ReadAsStringAsync();
                            result.Data = JsonSerializer.Deserialize<NegocioUpdateModal>(resp);
                        }
                        else
                        {
                            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                resp = await response.Content.ReadAsStringAsync();
                                result.Data = JsonSerializer.Deserialize<NegocioUpdateModal>(resp);
                                return result;
                            }
                            else
                            {
                                result.Success = false;
                                result.Message = "Error conectandose al end point de Update Negocio.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el negocio.";
                this._logger.LogError(result.Message, ex.ToString()); ;
            }
            return result;
        }

    }
}
