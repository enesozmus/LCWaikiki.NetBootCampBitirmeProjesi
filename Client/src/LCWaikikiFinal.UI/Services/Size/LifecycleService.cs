using LCWaikikiFinal.UI.Models;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Services
{
        public class SizeService : ISizeService
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public SizeService(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                public async Task<IReadOnlyList<GetSizesViewModel>> GetSizesAsync()
                {
                        var client = _httpClientFactory.CreateClient();
                        //var token = System.Security.Claims.ClaimsPrincipal.User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync("http://localhost:5006/api/Sizes");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var listOfSizes = JsonSerializer.Deserialize<IReadOnlyList<GetSizesViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });

                                return listOfSizes;
                        }
                        return null;
                }
        }
}
