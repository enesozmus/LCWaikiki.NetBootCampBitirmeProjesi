using FluentValidation.AspNetCore;
using LCWaikikiFinal.UI.ValidationRules;

namespace LCWaikikiFinal.UI.Extensions;

public static class FluentValidatidonsRegister
{
        public static void AddFluentValidators(this IServiceCollection builder)
        {
                builder.AddControllersWithViews()
                        .AddFluentValidation(
                         a => a.RegisterValidatorsFromAssemblyContaining<LoginValidator>()
                         )
                        .AddFluentValidation(
                         a => a.RegisterValidatorsFromAssemblyContaining<RegisterValidator>()
                         )
                        .AddFluentValidation(
                         a => a.RegisterValidatorsFromAssemblyContaining<CreateOfferValidator>()
                         )
                        .AddFluentValidation(
                        a => a.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()
                        );
        }
}
