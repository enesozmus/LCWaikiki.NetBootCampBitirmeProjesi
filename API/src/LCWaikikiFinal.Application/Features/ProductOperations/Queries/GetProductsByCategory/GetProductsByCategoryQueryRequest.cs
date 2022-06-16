using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsByCategoryQueryRequest : IRequest<IReadOnlyList<GetProductsByCategoryQueryResponse>>
        {
                public GetProductsByCategoryQueryRequest(int? id)
                {
                        Id = id;
                }

                public int? Id { get; set; }
        }
}
