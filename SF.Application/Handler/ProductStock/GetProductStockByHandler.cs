using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.ProductStock.GetBy;
using SF.Domain.Interface;

namespace SF.Application.Handler.ProductStock
{
    public class GetProductStockByHandler : IRequestHandler<GetProductStockByIdRequest, GetProductStockByIdResponse>
    {
        private readonly IProductStockRepository _productStockRepository;
        private readonly IValidator<GetProductStockByIdRequest> _validator;
        private readonly IMapper _mapper;

        public GetProductStockByHandler(IProductStockRepository productStockRepository, IValidator<GetProductStockByIdRequest> validator, IMapper mapper)
        {
            _productStockRepository = productStockRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<GetProductStockByIdResponse> Handle(GetProductStockByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _productStockRepository.GetProductStockBy(request.Id, cancellationToken);
            return _mapper.Map<GetProductStockByIdResponse>(response);
        }
    }
}