using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class ProductStockRepository : IProductStockRepository
    {
        private readonly SFContext _context;

        public ProductStockRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateProductStock(ProductStock productStock, CancellationToken cancellationToken)
        {
            if(productStock == null)
                throw new Exception("ProductStock is null");

            await _context.ProductStock.AddAsync(productStock, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "ProductStock created" : "Error creating ProductStock";
        }

        public async Task<ProductStock> GetProductStockBy(int id, CancellationToken cancellationToken)
        {
            return await _context.ProductStock.FirstOrDefaultAsync(p => p.Id == id, cancellationToken)?? new ProductStock();
        }

        public async Task<List<ProductStock>> GetProductStocks(CancellationToken cancellationToken)
        {
            return await _context.ProductStock.ToListAsync(cancellationToken);
        }

        public async Task<string> UpdateProductStock(ProductStock productStock, CancellationToken cancellationToken)
        {
            if(productStock == null)
                throw new Exception("ProductStock is null");

            _context.ProductStock.Update(productStock);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "ProductStock Updated" : "Error updating ProductStock";
        }
    }
}