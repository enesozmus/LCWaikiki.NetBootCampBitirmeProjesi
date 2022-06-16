using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsQueryRequest : IRequest<IReadOnlyList<GetProductsQueryResponse>> { }
}
