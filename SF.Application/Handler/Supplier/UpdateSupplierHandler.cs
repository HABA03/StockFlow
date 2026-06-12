using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Domain.Interface;
using SF.Supplier.DTO.Supplier.Update;

namespace SF.Application.Handler.Supplier
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierRequest, UpdateSupplierResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateSupplierRequest> _validator;

        public UpdateSupplierHandler(ISupplierRepository supplierRepository, IMapper mapper, IValidator<UpdateSupplierRequest> validator)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateSupplierResponse> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _supplierRepository.UpdateSupplier(_mapper.Map<Domain.Entity.Supplier>(request), cancellationToken);
            return new UpdateSupplierResponse{ Response = response };
        }
    }
}