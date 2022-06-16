using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.SizeOperations.Queries
{
        public class GetSizesQueryHandler : IRequestHandler<GetSizesQueryRequest, IReadOnlyList<GetSizesQueryResponse>>
        {
                private readonly ISizeReadRepository _sizeReadRepository;
                private readonly IMapper _mapper;

                public GetSizesQueryHandler(ISizeReadRepository sizeReadRepository, IMapper mapper)
                {
                        _sizeReadRepository = sizeReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetSizesQueryResponse>> Handle(GetSizesQueryRequest request, CancellationToken cancellationToken)
                {
                        var sizes = await _sizeReadRepository.GetAllAsync();
                        return _mapper.Map<IReadOnlyList<GetSizesQueryResponse>>(sizes);
                }
        }
}
