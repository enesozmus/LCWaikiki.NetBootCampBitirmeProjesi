using MediatR;

namespace LCWaikikiFinal.Application.Features.BrandOperations.Queries
{
        public class GetBrandsQueryRequest : IRequest<IReadOnlyList<GetBrandsQueryResponse>> { }
}
