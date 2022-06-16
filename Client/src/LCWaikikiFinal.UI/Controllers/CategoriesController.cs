using LCWaikikiFinal.UI.Models;
using LCWaikikiFinal.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LCWaikikiFinal.UI.Controllers
{
        public class CategoriesController : Controller
        {
                private readonly IHttpClientFactory _httpClientFactory;
                private readonly ICategoryService _categoryService;

                public CategoriesController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
                {
                        _httpClientFactory = httpClientFactory;
                        _categoryService = categoryService;
                }


                #region Bütün Kategorileri Getir

                public async Task<IActionResult> Index()
                {
                        var listOfCategories = await _categoryService.GetCategoriesAsync();
                        if (listOfCategories != null)
                        {
                                return View(listOfCategories);
                        }
                        return RedirectToAction("Index", "Home");
                }

                #endregion
        }
}
