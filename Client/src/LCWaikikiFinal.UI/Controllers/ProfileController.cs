using LCWaikikiFinal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Controllers
{
        public class ProfileController : Controller
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public ProfileController(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                #region Kullanıcıya Ait Ürünleri Getir

                public async Task<IActionResult> Index(int id)
                {
                        var client = _httpClientFactory.CreateClient();
                        var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        var response = await client.GetAsync($"http://localhost:5006/api/Profile/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var productsOfUser = JsonSerializer.Deserialize<IReadOnlyList<GetProductsByUserViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });
                                return View(productsOfUser);
                        }
                        return RedirectToAction("Index", "Home");
                }

                #endregion
        }
}
