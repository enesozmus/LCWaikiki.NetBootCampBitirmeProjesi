using FluentValidation;
using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.ValidationRules
{
        public class RegisterValidator : AbstractValidator<UserRegisterModel>
        {
                public RegisterValidator()
                {
                        RuleFor(p => p.FirstName).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için ad alanını lütfen doldurun!");
                        RuleFor(p => p.LastName).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için soyadı alanını lütfen doldurun!");
                        RuleFor(p => p.UserName).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için kullanıcı adı alanını lütfen doldurun!");
                        RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için email alanını lütfen doldurun!");
                        RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("Kayıt olabilmek için parola alanını lütfen doldurun!");

                        RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad alanı 2 karakterden az olmamalı!");
                        RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyadı alanı 2 karakterden az olmamalı!");
                        RuleFor(p => p.UserName).MinimumLength(2).WithMessage("Kullanıcı adı alanı 2 karakterden az olmamalı!");
                        RuleFor(p => p.Email).MinimumLength(8).WithMessage("Email alanı 8 karakterden az olmamalı!");
                        RuleFor(p => p.Password).MinimumLength(8).WithMessage("Parola alanı 8 karakterden az olmamalı!");

                        RuleFor(p => p.FirstName).MaximumLength(15).WithMessage("Ad alanı 15 karakterden fazla olmamalı!");
                        RuleFor(p => p.LastName).MaximumLength(15).WithMessage("Soyadı alanı 15 karakterden fazla olmamalı!");
                        RuleFor(p => p.UserName).MaximumLength(20).WithMessage("Kullanıcı adı alanı 20 karakterden fazla olmamalı!");
                        RuleFor(p => p.Email).MaximumLength(20).WithMessage("Email alanı 20 karakterden fazla olmamalı!");
                        RuleFor(p => p.Password).MaximumLength(20).WithMessage("Parola alanı 20 karakterden fazla olmamalı!");

                        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Parola alanı en az bir büyük karakter içermelidir!");
                        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Parola alanı en az bir küçük karakter içermelidir!");
                        RuleFor(p => p.Password).Matches(@"\d").WithMessage("Parola alanı en az bir rakam karakter içermelidir!");
                        RuleFor(p => p.Password).Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("Parola alanı en az bir alfanümerik olmayan karakter içermelidir!");

                        RuleFor(x => x.PhoneNumber).Matches("(05|5)[0-9][0-9][ ][1-9]([0-9]){2}[ ]([0-9]){4}").WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");
                        RuleFor(x => x.PhoneNumber).MaximumLength(13).MinimumLength(13);
                }
        }
}
