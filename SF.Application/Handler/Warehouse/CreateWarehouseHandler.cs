using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Warehouse.Create;
using SF.Domain.Interface;

namespace SF.Application.Handler.Warehouse
{
    public class CreateWarehouseHandler : IRequestHandler<CreateWarehouseRequest, CreateWarehouseResponse>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateWarehouseRequest> _validator;

        public CreateWarehouseHandler(IWarehouseRepository warehouseRepository, IMapper mapper, IValidator<CreateWarehouseRequest> validator)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateWarehouseResponse> Handle(CreateWarehouseRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _warehouseRepository.CreateWarehouse(_mapper.Map<Domain.Entity.Warehouse>(request), cancellationToken);
            return new CreateWarehouseResponse{ Response = response };
        }
    }
}