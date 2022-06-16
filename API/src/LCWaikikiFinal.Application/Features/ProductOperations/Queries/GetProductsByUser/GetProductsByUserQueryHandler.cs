using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsByUserQueryHandler : IRequestHandler<GetProductsByUserQueryRequest, IReadOnlyList<GetProductsByUserQueryResponse>>
        {
                private readonly IProductReadRepository _productReadRepository;

                private readonly IMapper _mapper;

                public GetProductsByUserQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
                {
                        _productReadRepository = ProductReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetProductsByUserQueryResponse>> Handle(GetProductsByUserQueryRequest request, CancellationToken cancellationToken)
                {
                        var productsOfUser = await _productReadRepository.GetAsync(x => x.AppUserId == request.Id);
                        return _mapper.Map<IReadOnlyList<GetProductsByUserQueryResponse>>(productsOfUser);
                }
        }
}
