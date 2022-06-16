using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Command;

public class CreateOfferCommandRequest : IRequest
{
        public int OfferPrice { get; set; }
        public int ProductId { get; set; }
        public int AppUserId { get; set; }
}