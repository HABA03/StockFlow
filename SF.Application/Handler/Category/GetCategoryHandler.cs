using AutoMapper;
using MediatR;
using SF.Application.DTO.Category.Get;
using SF.Domain.Interface;

namespace SF.Application.Handler.Category
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, List<GetCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryResponse>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.GetCategories(cancellationToken);
            return _mapper.Map<List<GetCategoryResponse>>(response);
        }
    }
}