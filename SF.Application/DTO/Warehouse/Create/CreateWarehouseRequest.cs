using MediatR;

namespace SF.Application.DTO.Warehouse.Create
{
    public class CreateWarehouseRequest : IRequest<CreateWarehouseResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
    }
}