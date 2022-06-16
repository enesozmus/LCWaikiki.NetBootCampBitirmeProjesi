using AutoMapper;
using LCWaikikiFinal.Application.IRepositories;
using LCWaikikiFinal.Application.Response;
using LCWaikikiFinal.Domain.Entities;
using MediatR;

namespace LCWaikikiFinal.Application.Features.CategoryOperations.Command
{
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest>
        {
                private readonly ICategoryWriteRepository _categoryWriteRepository;
                private readonly IMapper _mapper;

                public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
                {
                        _categoryWriteRepository = categoryWriteRepository;
                        _mapper = mapper;
                }

                public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
                {
                        var response = new ResponseBase<bool>(true);
                        var category = _mapper.Map<Category>(request);
                        await _categoryWriteRepository.AddAsync(category);
                        await _categoryWriteRepository.SaveAsync();
                        return Unit.Value;
                }
        }
}
