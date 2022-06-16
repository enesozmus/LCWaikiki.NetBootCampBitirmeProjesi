using LCWaikikiFinal.UI.Models;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Services
{
        public class LifecycleService : ILifecycleService
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public LifecycleService(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                public async Task<IReadOnlyList<GetLifecyclesViewModel>> GetLifecyclesAsync()
                {
                        var client = _httpClientFactory.CreateClient();
                        //var token = System.Security.Claims.ClaimsPrincipal.User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync("http://localhost:5006/api/Lifecycles");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var listOfLifecycles = JsonSerializer.Deserialize<IReadOnlyList<GetLifecyclesViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });

                                return listOfLifecycles;
                        }
                        return null;
                }
        }
}
