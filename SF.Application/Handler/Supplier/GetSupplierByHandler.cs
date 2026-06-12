using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Domain.Interface;
using SF.Supplier.DTO.Supplier.GetBy;

namespace SF.Application.Handler.Supplier
{
    public class GetSupplierByHandler : IRequestHandler<GetSupplierByIdRequest, GetSupplierByIdResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetSupplierByIdRequest> _validator;

        public GetSupplierByHandler(ISupplierRepository supplierRepository, IMapper mapper, IValidator<GetSupplierByIdRequest> validator)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetSupplierByIdResponse> Handle(GetSupplierByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _supplierRepository.GetSupplierBy(request.Id, cancellationToken);
            return _mapper.Map<GetSupplierByIdResponse>(response);
        }
    }
}