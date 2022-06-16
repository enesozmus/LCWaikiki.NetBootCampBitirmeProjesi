using FluentValidation;
using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.ValidationRules
{
        public class LoginValidator : AbstractValidator<UserLoginModel>
        {
                public LoginValidator()
                {
                        RuleFor(p => p.Email).NotEmpty().WithMessage("email gir abi");
                        RuleFor(p => p.Email).MinimumLength(8).WithMessage("en az 8 harf abi");
                        RuleFor(p => p.Email).MaximumLength(20).WithMessage("en fazla 20 harf abi");
                        RuleFor(p => p.Password).NotEmpty().WithMessage("{Password} alanini doldurmaniz gerekiyor.");
                        RuleFor(p => p.Password).MinimumLength(8).WithMessage("en az 8 Password harf abi");
                }
        }
}
