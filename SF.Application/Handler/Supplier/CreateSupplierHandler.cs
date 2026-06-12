using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Domain.Interface;
using SF.Supplier.DTO.Supplier.Create;

namespace SF.Application.Handler.Supplier
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierRequest, CreateSupplierResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSupplierRequest> _validator;

        public CreateSupplierHandler(IValidator<CreateSupplierRequest> validator, IMapper mapper, ISupplierRepository supplierRepository)
        {
            _validator = validator;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<CreateSupplierResponse> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _supplierRepository.CreateSupplier(_mapper.Map<Domain.Entity.Supplier>(request), cancellationToken);
            return new CreateSupplierResponse{ Response = response };
        }
    }
}