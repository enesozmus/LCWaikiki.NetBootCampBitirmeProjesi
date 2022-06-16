using LCWaikikiFinal.UI.Models;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Services
{
        public class BrandService : IBrandService
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public BrandService(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                public async Task<IReadOnlyList<GetBrandsViewModel>> GetBrandsAsync()
                {
                        var client = _httpClientFactory.CreateClient();
                        //var token = System.Security.Claims.ClaimsPrincipal.User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync("http://localhost:5006/api/Brands");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var listOfBrands = JsonSerializer.Deserialize<IReadOnlyList<GetBrandsViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });

                                return listOfBrands;
                        }
                        return null;
                }
        }
}
