using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductDetailQueryRequest : IRequest<GetProductDetailQueryResponse>
        {
                public GetProductDetailQueryRequest(int id)
                {
                        Id = id;
                }

                public int Id { get; set; }
        }
}
