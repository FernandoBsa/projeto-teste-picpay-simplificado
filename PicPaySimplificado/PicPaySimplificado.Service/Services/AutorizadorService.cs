using System.Text.Json;
using System.Text.Json.Serialization;
using PicPaySimplificado.Service.Interfaces;

namespace PicPaySimplificado.Service.Services
{
    public class AutorizadorService : IAutorizadorService
    {
        private readonly HttpClient _httpClient;
        private const string URL = "https://util.devi.tools/api/v2/authorize";
        public AutorizadorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        public async Task<bool> AuthorizeAsync()
        {
            string content = string.Empty;

            var response = await _httpClient.GetAsync(URL);

            if (!response.IsSuccessStatusCode)
                return false;

            response.EnsureSuccessStatusCode();

            content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse>(content);

            return result?.status == "success";
        }

        private class ApiResponse
        {
            public string status { get; set; }
            public DataResponse data { get; set; }
        }

        private class DataResponse
        {
            public bool authorization { get; set; }
        }
    }
}
