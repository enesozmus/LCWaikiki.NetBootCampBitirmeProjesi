using LCWaikikiFinal.Application.Response;
using MediatR;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Command
{
        public class CreateCategoryCommandRequest : IRequest
        {
                public string Name { get; set; }
                public string Description { get; set; }
        }
}
