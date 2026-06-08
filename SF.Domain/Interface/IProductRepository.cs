using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface IProductRepository
    {
        Task<string> CreateProduct(Product product, CancellationToken cancellationToken);
        Task<string> UpdateProduct(Product product, CancellationToken cancellationToken);
        Task<Product> GetProductBy(int id, CancellationToken cancellationToken);
        Task<List<Product>> GetProducts(CancellationToken cancellationToken);
    }
}