using MediatR;

namespace SF.Application.DTO.Warehouse.GetBy
{
    public class GetWarehouseByIdRequest : IRequest<GetWarehouseByIdResponse>
    {
        public int Id { get; set; }
    }
}