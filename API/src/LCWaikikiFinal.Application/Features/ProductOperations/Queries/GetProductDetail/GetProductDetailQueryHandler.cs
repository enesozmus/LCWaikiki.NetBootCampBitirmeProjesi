using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQueryRequest, GetProductDetailQueryResponse>
        {
                private readonly IProductReadRepository _productReadRepository;
                private readonly IMapper _mapper;

                public GetProductDetailQueryHandler(IProductReadRepository ProductReadRepository, IMapper mapper)
                {
                        _productReadRepository = ProductReadRepository;
                        _mapper = mapper;
                }

                public async Task<GetProductDetailQueryResponse> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken)
                {
                        var products = await _productReadRepository.GetProductForDetail(request.Id);
                        return _mapper.Map<GetProductDetailQueryResponse>(products);
                }
        }
}
