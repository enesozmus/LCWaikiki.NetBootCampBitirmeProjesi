using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using MediatR;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Queries
{
        public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQueryRequest, GetCategoryDetailQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoryDetailQueryResponse> Handle(GetCategoryDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryReadRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetCategoryDetailQueryResponse>(category);
        }
    }
}
