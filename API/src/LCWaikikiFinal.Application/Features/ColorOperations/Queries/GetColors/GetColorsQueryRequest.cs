using MediatR;

namespace LCWaikikiFinal.Application.Features.ColorOperations.Queries
{
        public class GetColorsQueryRequest : IRequest<IReadOnlyList<GetColorsQueryResponse>> { }
}
