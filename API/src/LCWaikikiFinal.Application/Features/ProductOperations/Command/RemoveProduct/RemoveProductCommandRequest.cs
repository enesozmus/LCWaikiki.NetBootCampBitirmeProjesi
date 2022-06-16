using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Command
{
        public class RemoveProductCommandRequest : IRequest
        {
                public int Id { get; set; }
        }
}
