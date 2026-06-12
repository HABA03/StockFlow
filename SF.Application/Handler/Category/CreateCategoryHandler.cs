using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Category.Create;
using SF.Domain.Interface;

namespace SF.Application.Handler
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<CreateCategoryRequest> _validator;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IValidator<CreateCategoryRequest> validator, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _categoryRepository.CreateCategory(_mapper.Map<Domain.Entity.Category>(request), cancellationToken);
            return new CreateCategoryResponse { Response = response };
        }
    }
}