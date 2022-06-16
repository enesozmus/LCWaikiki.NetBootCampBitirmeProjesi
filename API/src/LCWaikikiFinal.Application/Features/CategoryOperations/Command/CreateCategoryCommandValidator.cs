using FluentValidation;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Command
{
        public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
        {
                public CreateCategoryCommandValidator()
                {
                        RuleFor(x => x.Name).MinimumLength(3).WithMessage("en az 3!");
                        RuleFor(x => x.Description).MinimumLength(10).WithMessage("en az 10!");
                }
        }
}
