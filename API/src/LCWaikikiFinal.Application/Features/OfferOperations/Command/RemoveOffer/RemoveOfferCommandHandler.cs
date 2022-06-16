using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Command
{
        public class RemoveOfferCommandHandler : IRequestHandler<RemoveOfferCommandRequest>
        {
                private readonly IOfferReadRepository _offerReadRepository;
                private readonly IOfferWriteRepository _offerWriteRepository;

                public RemoveOfferCommandHandler(IOfferReadRepository offerReadRepository, IOfferWriteRepository offerWriteRepository)
                {
                        _offerReadRepository = offerReadRepository;
                        _offerWriteRepository = offerWriteRepository;
                }

                public async Task<Unit> Handle(RemoveOfferCommandRequest request, CancellationToken cancellationToken)
                {
                        var deleteOffer = await _offerReadRepository.GetByIdAsync(request.Id);
                        if (deleteOffer != null)
                        {
                                await _offerWriteRepository.RemoveAsync(deleteOffer);
                                await _offerWriteRepository.SaveAsync();
                        }
                        return Unit.Value;
                }
        }
}
