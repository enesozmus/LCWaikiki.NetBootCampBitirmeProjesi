using FluentValidation;

namespace LCWaikikiFinal.UI.ValidationRules
{
        public class FormFileValidator : AbstractValidator<IFormFile>
        {
                public FormFileValidator()
                {
                        RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(400000).WithMessage("Görselin  boyutu 400kb'dan fazla olamaz!");
                        RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                           .WithMessage("Sadece png, jpg ve jpeg formatlarını destekler!");
                }
        }
}
