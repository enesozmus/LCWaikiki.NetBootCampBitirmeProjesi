using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsByUserQueryRequest : IRequest<IReadOnlyList<GetProductsByUserQueryResponse>>
        {
                public GetProductsByUserQueryRequest(int id)
                {
                        Id = id;
                }

                public int Id { get; set; }
        }
}
