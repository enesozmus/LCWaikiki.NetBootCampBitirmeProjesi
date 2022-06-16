using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.ColorOperations.Queries
{
        public class GetColorsQueryHandler : IRequestHandler<GetColorsQueryRequest, IReadOnlyList<GetColorsQueryResponse>>
        {
                private readonly IColorReadRepository _colorReadRepository;
                private readonly IMapper _mapper;

                public GetColorsQueryHandler(IColorReadRepository colorReadRepository, IMapper mapper)
                {
                        _colorReadRepository = colorReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetColorsQueryResponse>> Handle(GetColorsQueryRequest request, CancellationToken cancellationToken)
                {
                        var colors = await _colorReadRepository.GetAllAsync();
                        return _mapper.Map<IReadOnlyList<GetColorsQueryResponse>>(colors);
                }
        }
}
