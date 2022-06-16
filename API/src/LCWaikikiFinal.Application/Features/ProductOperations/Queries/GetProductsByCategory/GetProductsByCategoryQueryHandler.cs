using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQueryRequest, IReadOnlyList<GetProductsByCategoryQueryResponse>>
        {
                private readonly IProductReadRepository _productReadRepository;
                private readonly IMapper _mapper;

                public GetProductsByCategoryQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
                {
                        _productReadRepository = productReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetProductsByCategoryQueryResponse>> Handle(GetProductsByCategoryQueryRequest request, CancellationToken cancellationToken)
                {
                        var categoryWithProducts = await _productReadRepository.GetProductsByCategory(x => x.CategoryId == request.Id);
                        return _mapper.Map<IReadOnlyList<GetProductsByCategoryQueryResponse>>(categoryWithProducts);
                }
        }
}
