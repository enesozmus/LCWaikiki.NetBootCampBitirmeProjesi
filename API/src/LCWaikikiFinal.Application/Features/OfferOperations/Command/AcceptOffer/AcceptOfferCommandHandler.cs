using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Command.AcceptOffer;

internal class AcceptOfferCommandHandler : IRequestHandler<AcceptOfferCommandRequest>
{
        private readonly IOfferWriteRepository _offerWriteRepository;
        private readonly IOfferReadRepository _offerReadRepository;
        private readonly IMapper _mapper;

        public AcceptOfferCommandHandler(IOfferWriteRepository offerWriteRepository, IOfferReadRepository offerReadRepository, IMapper mapper)
        {
                _offerWriteRepository = offerWriteRepository;
                _offerReadRepository = offerReadRepository;
                _mapper = mapper;
        }

        public async Task<Unit> Handle(AcceptOfferCommandRequest request, CancellationToken cancellationToken)
        {
                var offer = await _offerReadRepository.GetByIdAsync(request.Id);
                offer.IsAccepted = true;

                await _offerWriteRepository.UpdateAsync(offer);
                await _offerWriteRepository.SaveAsync();

                return Unit.Value;
        }
}
