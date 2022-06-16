using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Command
{
        public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommandRequest>
        {
                private readonly IOfferWriteRepository _offerWriteRepository;
                private readonly IMapper _mapper;

                public CreateOfferCommandHandler(IOfferWriteRepository offerWriteRepository, IMapper mapper)
                {
                        _offerWriteRepository = offerWriteRepository;
                        _mapper = mapper;
                }

                public async Task<Unit> Handle(CreateOfferCommandRequest request, CancellationToken cancellationToken)
                {
                        var offerEntity = _mapper.Map<Offer>(request);
                        await _offerWriteRepository.AddAsync(offerEntity);
                        await _offerWriteRepository.SaveAsync();
                        return Unit.Value;
                }
        }
}
