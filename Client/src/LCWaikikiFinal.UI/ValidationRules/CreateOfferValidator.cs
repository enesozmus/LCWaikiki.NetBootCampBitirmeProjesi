using FluentValidation;
using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.ValidationRules
{
        public class CreateOfferValidator : AbstractValidator<CreateOfferViewModel>
        {
                public CreateOfferValidator()
                {
                        RuleFor(p => p.OfferPrice).NotEmpty().WithMessage("Teklif işlemi için fiyat bilgisi gereklidir!");
                        RuleFor(p => p.OfferPrice).GreaterThan(0).WithMessage("Teklif değeriniz 0'dan büyük olmalıdır!");
                }
        }
}
