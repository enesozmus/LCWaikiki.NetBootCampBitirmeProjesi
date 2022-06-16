using MediatR;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Queries
{
    public class GetCategoryDetailQueryRequest : IRequest<GetCategoryDetailQueryResponse>
    {
        public int Id { get; set; }
    }
}