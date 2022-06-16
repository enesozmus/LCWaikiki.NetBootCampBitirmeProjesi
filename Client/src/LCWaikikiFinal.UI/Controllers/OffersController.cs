using LCWaikikiFinal.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Controllers
{
        public class OffersController : Controller
        {
                private readonly IHttpClientFactory _httpClientFactory;

                public OffersController(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                #region Kullanıcıya Ait Teklifleri Getir
                
                public async Task<IActionResult> Index(int id)
                {
                        var client = _httpClientFactory.CreateClient();
                        var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        //if (httpContext.HasCookie("Authorization"))
                        //{
                        //        //var myCookie = httpContext.GetCookie("Authorization");
                        //        //request.Headers.TryAddWithoutValidation("Authorization", myCookie);

                        //        var getCookie = httpContext.GetCookie("Authorization");
                        //        var myCookie = JsonConvert.DeserializeObject<ServiceResponse<LoginModel>>(getCookie);
                        //        request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + myCookie.Data.Token);
                        //}


                        var response = await client.GetAsync($"http://localhost:5006/api/Offers/{id}");
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var offersOfUser = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetOffersByUserViewModel>>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });
                                return View(offersOfUser);
                        }
                        return RedirectToAction("Index", "Home");
                }

                #endregion

                #region Teklifi Geri Çek Opsiyonu

                //[HttpDelete]
                public async Task<IActionResult> Remove(int id)
                {
                        var client = CreateClient();
                        await client.DeleteAsync($"http://localhost:5006/api/Offers/{id}");
                        return RedirectToAction("Index");
                }

                #endregion

                #region Teklif Yap Opsiyonu

                public IActionResult CreateOffer(int id)
                {
                        // asp-route-id olarak getirip parametre olarak aldığımız teklif yapacağımız ürünün ID'sini diğer Action'a taşıyoruz.
                        TempData["UrunID"] = id;

                        return View();
                }

                [HttpPost]
                public async Task<IActionResult> CreateOffer(CreateOfferViewModel offerModel)
                {
                        #region Urun ID
                        var UrunID = TempData["UrunID"];
                        if (UrunID != null)
                                offerModel.ProductId = (int)UrunID;
                        #endregion


                        if (ModelState.IsValid)
                        {
                                var client = CreateClient();
                                var jsonData = JsonConvert.SerializeObject(offerModel);
                                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                                var response = await client.PostAsync("http://localhost:5006/api/Offers", content);

                                if (response.IsSuccessStatusCode)
                                {
                                        return RedirectToAction("Index");
                                }
                                else
                                {
                                        TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {response.StatusCode}";
                                        return View(offerModel);
                                }
                        }
                        else
                        {
                                return View(offerModel);
                        }
                }

                #endregion

                #region HttpClient
                private HttpClient CreateClient()
                {
                        var client = _httpClientFactory.CreateClient();
                        var token = User.Claims.SingleOrDefault(x => x.Type == "accessToken")?.Value;
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                        return client;
                }
                #endregion
        }
}
