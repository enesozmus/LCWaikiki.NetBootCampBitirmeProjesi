using FluentValidation;
using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.ValidationRules
{
        public class CreateProductValidator : AbstractValidator<CreateProductViewModel>
        {
                public CreateProductValidator()
                {
                        RuleFor(x => x.Image).SetValidator(new FormFileValidator());

                        RuleFor(p => p.Name).NotEmpty().WithMessage("Kayıt işlemi için ürün adı gereklidir!");
                        RuleFor(p => p.Name).MinimumLength(2).WithMessage(" Kayıt işlemi için ürün adı iki karakterden az olamaz!");

                        RuleFor(p => p.Price).NotEmpty().WithMessage("Kayıt işlemi için fiyat bilgisi gereklidir!");
                        RuleFor(p => p.Price).LessThanOrEqualTo(1).WithMessage("Kayıt işlemi için fiyat bilgisi sıfırdan az olamaz!");
                        RuleFor(p => p.AmountOfStock).GreaterThan(0).WithMessage("Kayıt işlemi için adet bilgisi sıfırdan az olamaz!");

                        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kayıt işlemi için kategori bilgisi gereklidir!");
                        RuleFor(p => p.SizeId).NotEmpty().WithMessage("Kayıt işlemi için beden bilgisi gereklidir!");
                        //RuleFor(p => p.BrandId).NotEmpty().WithMessage("Kayıt işlemi için fiyat bilgisi gereklidir!");
                        //RuleFor(p => p.ColorId).NotEmpty().WithMessage("Kayıt işlemi için fiyat bilgisi gereklidir!");
                        RuleFor(p => p.LifecycleId).NotEmpty().WithMessage("Kayıt işlemi için kullanım durumu bilgisi gereklidir!");
                }
        }
}
