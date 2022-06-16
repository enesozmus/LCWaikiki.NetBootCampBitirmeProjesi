using MediatR;

namespace LCWaikikiFinal.Application.Features.LifecyclesOperations.Queries
{
        public class GetLifecyclesQueryRequest : IRequest<IReadOnlyList<GetLifecyclesQueryResponse>> { }
}
