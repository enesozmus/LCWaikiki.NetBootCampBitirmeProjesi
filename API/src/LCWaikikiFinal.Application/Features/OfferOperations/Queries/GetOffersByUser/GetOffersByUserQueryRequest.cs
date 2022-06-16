using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Queries
{
        public class GetOffersByUserQueryRequest : IRequest<IReadOnlyList<GetOffersByUserQueryResponse>>
        {
                public GetOffersByUserQueryRequest(int id)
                {
                        Id = id;
                }

                public int Id { get; set; }
        }
}
