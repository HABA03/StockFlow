using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.ProductStock.Create;
using SF.Domain.Interface;

namespace SF.Application.Handler.ProductStock
{
    public class CreateProductStockHandler : IRequestHandler<CreateProductStockRequest, CreateProductStockResponse>
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductStockRequest> _validator;

        public CreateProductStockHandler(IProductStockRepository productStockRepository, IMapper mapper, IValidator<CreateProductStockRequest> validator)
        {
            _productStockRepository = productStockRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateProductStockResponse> Handle(CreateProductStockRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _productStockRepository.CreateProductStock(_mapper.Map<Domain.Entity.ProductStock>(request), cancellationToken);
            return new CreateProductStockResponse{ Response = response };
        }
    }
}