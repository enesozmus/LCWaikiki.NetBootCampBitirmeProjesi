using LCWaikikiFinal.UI.Models;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Services
{
        public class ProductService : IProductService
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public ProductService(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                public async Task<IReadOnlyList<GetProductsViewModel>> GetProductsAsync()
                {
                        var client = _httpClientFactory.CreateClient();
                        //var token = System.Security.Claims.ClaimsPrincipal.User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync("http://localhost:5006/api/Products");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var listOfProducts = JsonSerializer.Deserialize<IReadOnlyList<GetProductsViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });
                                return listOfProducts;
                        }
                        return null;
                }
        }
}
