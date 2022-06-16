using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, IReadOnlyList<GetProductsQueryResponse>>
        {
                private readonly IProductReadRepository _productReadRepository;
                private readonly IMapper _mapper;

                public GetProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
                {
                        _productReadRepository = productReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetProductsQueryResponse>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
                {
                        var products = await _productReadRepository.GetAllProductsForIndex();
                        return _mapper.Map<IReadOnlyList<GetProductsQueryResponse>>(products);
                }
        }
}
