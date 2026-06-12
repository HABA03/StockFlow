using AutoMapper;
using FluentValidation;
using MediatR;
using SF.Application.DTO.Warehouse.GetBy;
using SF.Domain.Interface;

namespace SF.Application.Handler.Warehouse
{
    public class GetWarehouseByIdHandler : IRequestHandler<GetWarehouseByIdRequest, GetWarehouseByIdResponse>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetWarehouseByIdRequest> _validator;

        public GetWarehouseByIdHandler(IWarehouseRepository warehouseRepository, IMapper mapper, IValidator<GetWarehouseByIdRequest> validator)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetWarehouseByIdResponse> Handle(GetWarehouseByIdRequest request, CancellationToken cancellationToken)
        {
            var validationResponse = await _validator.ValidateAsync(request, cancellationToken);

            if(!validationResponse.IsValid)
                throw new ValidationException(validationResponse.Errors);

            var response = await _warehouseRepository.GetWarehouseBy(request.Id, cancellationToken);
            return _mapper.Map<GetWarehouseByIdResponse>(response);
        }
    }
}