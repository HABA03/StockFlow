using AutoMapper;
using MediatR;
using SF.Application.DTO.Warehouse.Get;
using SF.Domain.Interface;

namespace SF.Application.Handler.Warehouse
{
    public class GetWarehouseHandler : IRequestHandler<GetWarehouseRequest, List<GetWarehouseResponse>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public GetWarehouseHandler(IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<List<GetWarehouseResponse>> Handle(GetWarehouseRequest request, CancellationToken cancellationToken)
        {
            var warehousesInfo = await _warehouseRepository.GetWarehouses(cancellationToken);

            if(warehousesInfo == null)
                throw new Exception("Error getting info");

            return _mapper.Map<List<GetWarehouseResponse>>(warehousesInfo);
        }
    }
}