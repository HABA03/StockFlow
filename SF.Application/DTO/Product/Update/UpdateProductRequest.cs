using MediatR;

namespace SF.Application.DTO.Product.Update
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}