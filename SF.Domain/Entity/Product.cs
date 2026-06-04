using SF.Domain.Enum;

namespace SF.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedDated { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ProductStatusEnum Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();

        public List<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
    }
}