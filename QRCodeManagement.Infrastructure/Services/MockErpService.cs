using QRCodeManagement.Application.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace QRCodeManagement.Infrastructure.Services
{
    public class MockErpService : IErpService
    {
        private readonly HttpClient _httpClient;

        public MockErpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task NotifyNewCodeAsync(string code)
        {
            var payload = new { Code = code };
            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json");

            // Bu URL örnek/mock içindir,
            await _httpClient.PostAsync("https://webhook.site/8c1ff4af-0eed-4890-9732-e6a07dceb658", content);

        }
    }
}
