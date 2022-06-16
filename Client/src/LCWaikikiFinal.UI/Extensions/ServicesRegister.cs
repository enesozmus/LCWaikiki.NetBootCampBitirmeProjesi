using LCWaikikiFinal.UI.Services;

namespace LCWaikikiFinal.UI.Extensions;

public static class ServicesRegister
{
        public static void AddCustomServices(this IServiceCollection builder)
        {
                builder.AddScoped<ICategoryService, CategoryService>();
                builder.AddScoped<IProductService, ProductService>();
                builder.AddScoped<IBrandService, BrandService>();
                builder.AddScoped<IColorService, ColorService>();
                builder.AddScoped<ILifecycleService, LifecycleService>();
                builder.AddScoped<ISizeService, SizeService>();
        }
}
