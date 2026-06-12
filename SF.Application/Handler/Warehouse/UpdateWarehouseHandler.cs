using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Warehouse.Update;
using SF.Domain.Interface;

namespace SF.Application.Handler.Warehouse
{
    public class UpdateWarehouseHandler : IRequestHandler<UpdateWarehouseRequest, UpdateWarehouseResponse>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateWarehouseRequest> _validator;

        public UpdateWarehouseHandler(IWarehouseRepository warehouseRepository, IMapper mapper, IValidator<UpdateWarehouseRequest> validator)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateWarehouseResponse> Handle(UpdateWarehouseRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _warehouseRepository.UpdateWarehouse(_mapper.Map<Domain.Entity.Warehouse>(request), cancellationToken);
            return new UpdateWarehouseResponse{ Response = response };
        }
    }
}