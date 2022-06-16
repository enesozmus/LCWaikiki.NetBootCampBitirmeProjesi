using FluentValidation.AspNetCore;
using LCWaikikiFinal.UI.Extensions;
using LCWaikikiFinal.UI.Services;
using LCWaikikiFinal.UI.ValidationRules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

#region FluentValidation

builder.Services.AddFluentValidators();

#endregion

#region Services

builder.Services.AddCustomServices();

#endregion


#region JwtBearerDefaults

builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
        {
                options.LoginPath = "/Authentication/Login";
                options.LogoutPath = "/Authentication/Logout";
                options.AccessDeniedPath = "/Authentication/AccessDenied";
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.Name = "LCWFinal";
        });
#endregion

#region Others

//builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(c =>
//               c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

//builder.Services.AddHttpClient<ICategoryService, CategoryService>(c =>
//               c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

//builder.Services.AddHttpClient<IProductService, ProductService>(c =>
//               c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

//builder.Services.AddHttpClient<IAuthService, AuthService>(c =>
//   c.BaseAddress = new Uri(configuration["HttClientUrl:API"]));

//builder.Services.AddHttpContextAccessor();
//builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

//ActionResultExtensions.Configure(app.Services.GetRequiredService<IHttpContextAccessor>(),
//app.Services.GetRequiredService<ITempDataDictionaryFactory>());

#endregion


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

#region Identity

app.UseAuthentication();
app.UseAuthorization();

#endregion

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
