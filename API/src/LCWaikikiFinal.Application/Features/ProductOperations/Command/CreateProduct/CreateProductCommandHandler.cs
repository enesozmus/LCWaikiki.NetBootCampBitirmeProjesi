using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Domain.Entities;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Command
{
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
        {
                private readonly IProductWriteRepository _productWriteRepository;
                private readonly IMapper _mapper;

                public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
                {
                        _productWriteRepository = productWriteRepository;
                        _mapper = mapper;
                }

                public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
                {
                        var productEntity = _mapper.Map<Product>(request);
                        await _productWriteRepository.AddAsync(productEntity);
                        await _productWriteRepository.SaveAsync();
                        return Unit.Value;
                }
        }
}
