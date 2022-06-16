using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.LifecyclesOperations.Queries
{
        public class GetLifecyclesQueryHandler : IRequestHandler<GetLifecyclesQueryRequest, IReadOnlyList<GetLifecyclesQueryResponse>>
        {
                private readonly ILifecycleReadRepository _lifecycleReadRepository;
                private readonly IMapper _mapper;

                public GetLifecyclesQueryHandler(ILifecycleReadRepository lifecycleReadRepository, IMapper mapper)
                {
                        _lifecycleReadRepository = lifecycleReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetLifecyclesQueryResponse>> Handle(GetLifecyclesQueryRequest request, CancellationToken cancellationToken)
                {
                        var productStatus = await _lifecycleReadRepository.GetAllAsync();
                        return _mapper.Map<IReadOnlyList<GetLifecyclesQueryResponse>>(productStatus);
                }
        }
}
