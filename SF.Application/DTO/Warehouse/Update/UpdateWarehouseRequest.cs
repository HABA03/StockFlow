using MediatR;

namespace SF.Application.DTO.Warehouse.Update
{
    public class UpdateWarehouseRequest : IRequest<UpdateWarehouseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
    }
}