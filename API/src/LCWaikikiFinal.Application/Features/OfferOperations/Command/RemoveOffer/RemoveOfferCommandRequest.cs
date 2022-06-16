using MediatR;

namespace LCWaikikiFinal.Application.Features.OfferOperations.Command
{
        public class RemoveOfferCommandRequest : IRequest
        {
                public int Id { get; set; }
        }
}
