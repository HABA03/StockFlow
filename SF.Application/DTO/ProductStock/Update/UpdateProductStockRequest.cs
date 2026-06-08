using MediatR;

namespace SF.Application.DTO.ProductStock.Update
{
    public class UpdateProductStockRequest : IRequest<UpdateProductStockResponse>
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}