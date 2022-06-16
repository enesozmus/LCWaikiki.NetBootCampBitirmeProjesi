using MediatR;

namespace LCWaikikiFinal.Application.Features.SizeOperations.Queries
{
        public class GetSizesQueryRequest : IRequest<IReadOnlyList<GetSizesQueryResponse>> { }
}
