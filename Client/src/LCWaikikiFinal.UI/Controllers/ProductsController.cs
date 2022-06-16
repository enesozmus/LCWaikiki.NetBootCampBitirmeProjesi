using LCWaikikiFinal.UI.Models;
using LCWaikikiFinal.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Controllers
{
        public class ProductsController : Controller
        {
                private readonly IProductService _productService;
                private readonly IHttpClientFactory _httpClientFactory;
                private readonly ICategoryService _categoryService;
                private readonly IBrandService _brandService;
                private readonly IColorService _colorService;
                private readonly ILifecycleService _lifecycleService;
                private readonly ISizeService _sizeService;
                private readonly IWebHostEnvironment _webHostEnvironment;

                public ProductsController(IProductService productService, IHttpClientFactory httpClientFactory, ICategoryService categoryService, IBrandService brandService, IColorService colorService, ILifecycleService lifecycleService, ISizeService sizeService, IWebHostEnvironment webHostEnvironment)
                {
                        _productService = productService;
                        _httpClientFactory = httpClientFactory;
                        _categoryService = categoryService;
                        _brandService = brandService;
                        _colorService = colorService;
                        _lifecycleService = lifecycleService;
                        _sizeService = sizeService;
                        _webHostEnvironment = webHostEnvironment;
                }


                #region Bütün Ürünleri Getir

                public async Task<IActionResult> Index(int? id)
                {
                        var categories = await _categoryService.GetCategoriesAsync();

                        if (id != null)
                        {
                                var client = CreateClient();
                                var response = await client.GetAsync($"http://localhost:5006/api/Home/{id}");
                                if (response.IsSuccessStatusCode)
                                {
                                        var jsonString = await response.Content.ReadAsStringAsync();
                                        var productsByCategory = System.Text.Json.JsonSerializer.Deserialize<IReadOnlyList<GetProductsViewModel>>(jsonString, new JsonSerializerOptions
                                        {
                                                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                        });
                                        ProductsByCategoryForIndex productsByCategoryFor = new()
                                        {
                                                ProductItems = productsByCategory,
                                                CategoryItems = categories,
                                        };
                                        return View(productsByCategoryFor);
                                }
                        }
                        else
                        {
                                var products = await _productService.GetProductsAsync();
                                ProductsByCategoryForIndex productsByCategoryFor = new()
                                {
                                        ProductItems = products,
                                        CategoryItems = categories,
                                };
                                return View(productsByCategoryFor);
                        }
                        return BadRequest();
                }

                #endregion

                #region Ürün Detaylarını Getir

                public async Task<IActionResult> Detail(int id)
                {
                        var client = CreateClient();

                        var response = await client.GetAsync($"http://localhost:5006/api/Products/{id}");

                        if (response.IsSuccessStatusCode)
                        {
                                var jsonString = await response.Content.ReadAsStringAsync();

                                var productDetails = System.Text.Json.JsonSerializer.Deserialize<GetProductDetailViewModel>(jsonString, new JsonSerializerOptions
                                {
                                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                                });
                                return View(productDetails);
                        }
                        return RedirectToAction("Index", "Home");
                }

                #endregion

                #region Ürün Ekle

                public async Task<IActionResult> CreateProduct()
                {
                        await DropDownListViewBag();
                        return View(new CreateProductViewModel());
                }

                [HttpPost]
                public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
                {
                        string uniqueFileName = UploadedFile(createProductViewModel);
                        createProductViewModel.ImageUrl = uniqueFileName;

                        if (ModelState.IsValid)
                        {
                                await DropDownListViewBag();
                                var client = CreateClient();
                                var jsonData = JsonConvert.SerializeObject(createProductViewModel);
                                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                                var response = await client.PostAsync("http://localhost:5006/api/Products", content);

                                //var client = CreateClient();
                                //var request = new StringContent(JsonSerializer.Serialize(createProductViewModel), Encoding.UTF8, "application/json");
                                //var response = await client.PostAsync("http://localhost:5006/api/Products", request);

                                if (response.IsSuccessStatusCode)
                                {
                                        return RedirectToAction("Index", "Profile");
                                }
                                else
                                {
                                        TempData["errormessage"] = $"Bir hata ile karşılaşıldı! Hata kodu => {response.StatusCode}";
                                        return View(createProductViewModel);
                                }
                        }
                        else
                        {
                                await DropDownListViewBag();
                                return View(createProductViewModel);
                        }
                }

                #endregion

                #region Ürün Sil Opsiyonu

                //[HttpDelete]
                public async Task<IActionResult> RemoveProduct(int id)
                {
                        var client = CreateClient();
                        await client.DeleteAsync($"http://localhost:5006/api/Products/{id}");
                        return RedirectToAction("Index", "Profile");
                }

                #endregion


                #region ViewBag

                private async Task DropDownListViewBag()
                {
                        var categories = await _categoryService.GetCategoriesAsync();
                        ViewBag.Categories = new SelectList(categories, "Id", "Name");

                        var brands = await _brandService.GetBrandsAsync();
                        ViewBag.Brands = new SelectList(brands, "Id", "Name");

                        var color = await _colorService.GetColorsAsync();
                        ViewBag.Colors = new SelectList(color, "Id", "Name");

                        var lifecycle = await _lifecycleService.GetLifecyclesAsync();
                        ViewBag.Lifecycles = new SelectList(lifecycle, "Id", "Description");

                        var size = await _sizeService.GetSizesAsync();
                        ViewBag.Sizes = new SelectList(size, "Id", "Name");
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

                #region Upload Image

                private string UploadedFile(CreateProductViewModel createProductViewModel)
                {
                        string uniqueFileName = null;
                        if (createProductViewModel.Image != null)
                        {
                                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                                uniqueFileName = Guid.NewGuid().ToString() + "" + createProductViewModel.Image.FileName;
                                string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                        createProductViewModel.Image.CopyTo(fileStream);
                                }
                        }
                        return uniqueFileName;
                }

                #endregion
        }
}
