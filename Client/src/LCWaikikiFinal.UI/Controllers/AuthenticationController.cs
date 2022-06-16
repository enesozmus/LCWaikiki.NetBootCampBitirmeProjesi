using LCWaikikiFinal.UI.Extensions;
using LCWaikikiFinal.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Controllers
{
        public class AuthenticationController : Controller
        {
                //private readonly IAuthenticationService _authenticationService;
                private readonly IHttpClientFactory _httpClientFactory;

                public AuthenticationController(IHttpClientFactory httpClientFactory)
                {
                        _httpClientFactory = httpClientFactory;
                }

                #region Giriş Yap

                [HttpGet]
                public IActionResult Login()
                {
                        if (HttpContext.HasCookie("Authorization"))
                        {
                                //Kullanıcı daha önce giriş yapmış ise yapılacak işlemler
                                return RedirectToAction("Index", "Home");
                        }

                        return View();
                }

                [HttpPost]
                public async Task<IActionResult> Login(UserLoginModel loginModel)
                {
                        //string url = $"/api/Auth/LogIn?email={user.Email}&password={user.Password}";

                        var client = _httpClientFactory.CreateClient();
                        var request = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");
                        var response = await client.PostAsync("http://localhost:5006/api/Authentication/Login", request);
                        if (response.IsSuccessStatusCode)
                        {
                                var jsonData = await response.Content.ReadAsStringAsync();
                                var loginResponse = System.Text.Json.JsonSerializer.Deserialize<IdentityVerified>(jsonData, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });
                                JwtSecurityTokenHandler handler = new();
                                var token = handler.ReadJwtToken(loginResponse?.Token);
                                if (token != null)
                                {
                                        var claims = token.Claims.ToList();
                                        claims.Add(new Claim("accessToken", loginResponse?.Token == null ? "" : loginResponse.Token));
                                        var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                                        var authProps = new AuthenticationProperties
                                        {
                                                AllowRefresh = false,
                                                //ExpiresUtc = loginResponse?.ExpireDate,
                                                IsPersistent = true
                                        };
                                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProps);
                                        return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                        ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                                        return View(loginModel);
                                }
                        }
                        else
                        {
                                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                                return View(loginModel);
                        }
                }

                #endregion

                #region Kayıt Ol

                public IActionResult Register()
                {
                        if (HttpContext.HasCookie("Authorization"))
                        {
                                //Kullanıcı daha önce giriş yapmış ise yapılacak işlemler
                                return RedirectToAction("Index", "Home");
                        }

                        return View(new UserRegisterModel());
                }

                [HttpPost]
                public async Task<IActionResult> Register(UserRegisterModel registerModel)
                {
                        if (ModelState.IsValid)
                        {
                                var client = CreateClient();
                                var jsonData = JsonConvert.SerializeObject(registerModel);
                                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                                var response = await client.PostAsync("http://localhost:5006/api/Authentication/Register", content);

                                if (response.IsSuccessStatusCode)
                                {
                                        return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                        TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {response.StatusCode}";
                                        return View(registerModel);
                                }
                        }
                        return View(registerModel);
                }

                #endregion

                #region Kullanıcı Bilgilerini Getir

                public async Task<IActionResult> Detail(int id)
                {
                        var client = CreateClient();

                        var response = await client.GetAsync($"http://localhost:5006/api/Authentication/{id}");

                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var userDetails = System.Text.Json.JsonSerializer.Deserialize<GetUserDetailViewModel>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });
                                return View(userDetails);
                        }
                        return RedirectToAction("Index", "Home");
                }

                #endregion

                #region Çıkış Yap

                public IActionResult Logout()
                {
                        HttpContext.DeleteCookie("LCWFinal");
                        return RedirectToAction("Login");
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
