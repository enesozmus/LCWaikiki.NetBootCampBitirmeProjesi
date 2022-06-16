using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Queries
{
        public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, IReadOnlyList<GetCategoriesQueryResponse>>
        {
                private readonly ICategoryReadRepository _categoryReadRepository;
                private readonly IMapper _mapper;

                public GetCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
                {
                        _categoryReadRepository = categoryReadRepository;
                        _mapper = mapper;
                }

                public async Task<IReadOnlyList<GetCategoriesQueryResponse>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
                {
                        var categories = await _categoryReadRepository.GetAllAsync();

                        return _mapper.Map<IReadOnlyList<GetCategoriesQueryResponse>>(categories);
                }
        }
}
