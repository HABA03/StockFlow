using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Product.Create;
using SF.Domain.Interface;

namespace SF.Application.Handler.Product
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductRequest> _validator;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IValidator<CreateProductRequest> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _productRepository.CreateProduct(_mapper.Map<Domain.Entity.Product>(request), cancellationToken);
            return new CreateProductResponse{ Response = response };
        }
    }
}