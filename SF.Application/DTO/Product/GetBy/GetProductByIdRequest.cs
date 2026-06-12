using MediatR;

namespace SF.Application.DTO.Product.GetBy
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int Id { get; set; }
    }
}