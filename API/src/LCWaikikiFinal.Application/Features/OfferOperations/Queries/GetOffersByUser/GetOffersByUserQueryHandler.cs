using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Queries
{
        public class GetOffersByUserQueryHandler : IRequestHandler<GetOffersByUserQueryRequest, IReadOnlyList<GetOffersByUserQueryResponse>>
        {
                private readonly IOfferReadRepository _offerReadRepository;

                private readonly IMapper _mapper;

                public GetOffersByUserQueryHandler(IOfferReadRepository offerReadRepository, IMapper mapper)
                {
                        _offerReadRepository = offerReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetOffersByUserQueryResponse>> Handle(GetOffersByUserQueryRequest request, CancellationToken cancellationToken)
                {
                        var offersOfUser = await _offerReadRepository.GetOffersByUser(x => x.AppUserId == request.Id);
                        return _mapper.Map<IReadOnlyList<GetOffersByUserQueryResponse>>(offersOfUser);
                }
        }
}
