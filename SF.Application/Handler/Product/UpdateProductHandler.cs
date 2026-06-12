using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Product.Update;
using SF.Domain.Interface;

namespace SF.Application.Handler.Product
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProductRequest> _validator;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper, IValidator<UpdateProductRequest> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _productRepository.UpdateProduct(_mapper.Map<Domain.Entity.Product>(request), cancellationToken);
            return new UpdateProductResponse{ Response = response };
        }
    }
}