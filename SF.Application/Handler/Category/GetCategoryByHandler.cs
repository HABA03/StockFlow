using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Category.GetBy;
using SF.Domain.Interface;

namespace SF.Application.Handler.Category
{
    public class GetCategoryByHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetCategoryByIdRequest> _validator;

        public GetCategoryByHandler(ICategoryRepository categoryRepository, IMapper mapper, IValidator<GetCategoryByIdRequest> validator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _categoryRepository.GetCategoryBy(request.Id, cancellationToken);
            return _mapper.Map<GetCategoryByIdResponse>(response);
        }
    }
}