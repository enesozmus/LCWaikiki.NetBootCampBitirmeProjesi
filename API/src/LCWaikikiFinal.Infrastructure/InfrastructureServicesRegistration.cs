using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using LCWaikikiFinal.Infrastructure.Contexts;
using LCWaikikiFinal.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LCWaikikiFinal.Infrastructure
{
        public static class InfrastructureServicesRegistration
        {
                public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
                {
                        #region Microsoft SQL Server

                        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                        #endregion

                        #region Repositories

                        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
                        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

                        services.AddScoped<IProductReadRepository, ProductReadRepository>();
                        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

                        services.AddScoped<IOfferReadRepository, OfferReadRepository>();
                        services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();

                        services.AddScoped<IBrandReadRepository, BrandReadRepository>();
                        services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

                        services.AddScoped<IColorReadRepository, ColorReadRepository>();
                        services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

                        services.AddScoped<ILifecycleReadRepository, LifecycleReadRepository>();
                        services.AddScoped<ILifecycleWriteRepository, LifecycleWriteRepository>();

                        services.AddScoped<ISizeReadRepository, SizeReadRepository>();
                        services.AddScoped<ISizeWriteRepository, SizeWriteRepository>();

                        #endregion

                        #region Identity Library

                        services.AddIdentity<AppUser, AppRole>(options =>
                        {
                                options.Password.RequiredLength = 8;
                                options.Password.RequireNonAlphanumeric = true;
                                options.Password.RequireLowercase = true;
                                options.Password.RequireUppercase = true;
                                options.Password.RequireDigit = true;
                                options.User.RequireUniqueEmail = true;
                                options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";
                                //options.SignIn.RequireConfirmedAccount = false;
                                //options.SignIn.RequireConfirmedEmail = false;
                                //options.SignIn.RequireConfirmedPhoneNumber = false;
                                //options.Lockout.MaxFailedAccessAttempts = 3;
                                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                        }).AddEntityFrameworkStores<ApplicationDbContext>();

                        #endregion


                        return services;
                }
        }
}
