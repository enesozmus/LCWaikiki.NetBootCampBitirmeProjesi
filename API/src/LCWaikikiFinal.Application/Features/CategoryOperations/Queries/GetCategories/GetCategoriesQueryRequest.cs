using MediatR;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Queries
{
        public class GetCategoriesQueryRequest : IRequest<IReadOnlyList<GetCategoriesQueryResponse>> { }
}
