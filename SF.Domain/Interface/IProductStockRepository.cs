using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface IProductStockRepository
    {
        Task<string> CreateProductStock(ProductStock productStock, CancellationToken cancellationToken);
        Task<string> UpdateProductStock(ProductStock productStock, CancellationToken cancellationToken);
        Task<ProductStock> GetProductStockBy(int id, CancellationToken cancellationToken);
        Task<List<ProductStock>> GetProductStocks(CancellationToken cancellationToken);
    }
}