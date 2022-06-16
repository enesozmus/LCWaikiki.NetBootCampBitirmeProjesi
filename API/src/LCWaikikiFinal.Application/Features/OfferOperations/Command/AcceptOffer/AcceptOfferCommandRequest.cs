using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Command.AcceptOffer;

public class AcceptOfferCommandRequest : IRequest
{
        public int Id { get; set; }
}
