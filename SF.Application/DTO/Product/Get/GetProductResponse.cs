using SF.Domain.Enum;

namespace SF.Application.DTO.Product.Get
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedDated { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ProductStatusEnum Status { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}