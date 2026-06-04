using SF.Domain.Enum;

namespace SF.Domain.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public CategoryStatusEnum Status { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}