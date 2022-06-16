using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.BrandOperations.Queries
{
        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQueryRequest, IReadOnlyList<GetBrandsQueryResponse>>
        {
                private readonly IBrandReadRepository _brandReadRepository;
                private readonly IMapper _mapper;

                public GetBrandsQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
                {
                        _brandReadRepository = brandReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetBrandsQueryResponse>> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
                {
                        var brands = await _brandReadRepository.GetAllAsync();
                        return _mapper.Map<IReadOnlyList<GetBrandsQueryResponse>>(brands);
                }
        }
}
