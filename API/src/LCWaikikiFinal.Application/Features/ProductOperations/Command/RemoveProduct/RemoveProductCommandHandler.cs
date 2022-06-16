using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Command.RemoveProduct
{
        public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
        {
                private readonly IProductReadRepository _productReadRepository;
                private readonly IProductWriteRepository _productWriteRepository;

                public RemoveProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
                {
                        _productReadRepository = productReadRepository;
                        _productWriteRepository = productWriteRepository;
                }

                public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
                {
                        var deleteProduct = await _productReadRepository.GetByIdAsync(request.Id);
                        if (deleteProduct != null)
                        {
                                await _productWriteRepository.RemoveAsync(deleteProduct);
                                await _productWriteRepository.SaveAsync();
                        }
                        return Unit.Value;
                }
        }
}
