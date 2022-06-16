using LCWaikikiFinal.UI.Models;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Services
{
        public class ColorService : IColorService
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public ColorService(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                public async Task<IReadOnlyList<GetColorsViewModel>> GetColorsAsync()
                {
                        var client = _httpClientFactory.CreateClient();
                        //var token = System.Security.Claims.ClaimsPrincipal.User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync("http://localhost:5006/api/Colors");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var listOfColors = JsonSerializer.Deserialize<IReadOnlyList<GetColorsViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });

                                return listOfColors;
                        }
                        return null;
                }
        }
}
