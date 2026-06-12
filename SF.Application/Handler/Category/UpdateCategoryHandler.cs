using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Category.Update;
using SF.Domain.Interface;

namespace SF.Application.Handler.Category
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, UpdateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateCategoryRequest> _validator;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper, IValidator<UpdateCategoryRequest> validator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _categoryRepository.UpdateCategory(_mapper.Map<Domain.Entity.Category>(request), cancellationToken);
            return new UpdateCategoryResponse { Response = response };
        }
    }
}