using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Product.GetBy;
using SF.Domain.Interface;

namespace SF.Application.Handler.Product
{
    public class GetProductByHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetProductByIdRequest> _validator;

        public GetProductByHandler(IProductRepository productRepository, IMapper mapper, IValidator<GetProductByIdRequest> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _productRepository.GetProductBy(request.Id, cancellationToken);
            return _mapper.Map<GetProductByIdResponse>(response);
        }
    }
}