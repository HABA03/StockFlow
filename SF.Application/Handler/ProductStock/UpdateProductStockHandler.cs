using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.ProductStock.Update;
using SF.Domain.Interface;

namespace SF.Application.Handler.ProductStock
{
    public class UpdateProductStockHandler : IRequestHandler<UpdateProductStockRequest, UpdateProductStockResponse>
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProductStockRequest> _validator;

        public UpdateProductStockHandler(IProductStockRepository productStockRepository, IMapper mapper, IValidator<UpdateProductStockRequest> validator)
        {
            _productStockRepository = productStockRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateProductStockResponse> Handle(UpdateProductStockRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _productStockRepository.UpdateProductStock(_mapper.Map<Domain.Entity.ProductStock>(request), cancellationToken);
            return new UpdateProductStockResponse{ Response = response };
        }
    }
}