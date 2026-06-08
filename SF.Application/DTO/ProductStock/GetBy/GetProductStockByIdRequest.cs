using MediatR;

namespace SF.Application.DTO.ProductStock.GetBy
{
    public class GetProductStockByIdRequest : IRequest<GetProductStockByIdResponse>
    {
        public int Id { get; set; }
    }
}