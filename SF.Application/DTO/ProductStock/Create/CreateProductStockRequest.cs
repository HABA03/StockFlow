using MediatR;

namespace SF.Application.DTO.ProductStock.Create
{
    public class CreateProductStockRequest : IRequest<CreateProductStockResponse>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
    }
}