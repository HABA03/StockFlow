using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;
using SF.Domain.Enum;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly SFContext _context;

        public ProductRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            if(product == null)
                throw new Exception("Product is null");
            
            product.Status = ProductStatusEnum.Available;
            product.CreatedDated = DateTime.UtcNow;
            await _context.Product.AddAsync(product);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Product created" : "Error creating product";
        }

        public async Task<Product> GetProductBy(int id, CancellationToken cancellationToken)
        {
            return await _context.Product.FirstOrDefaultAsync(p => p.Id == id, cancellationToken)?? new Product();
        }

        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await _context.Product.Where(p => p.Status != ProductStatusEnum.Discontinued).ToListAsync(cancellationToken);
        }

        public async Task<string> UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            if(product == null)
                throw new Exception("Product is null");

            product.UpdatedDate = DateTime.UtcNow;
            _context.Product.Update(product);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Product updated" : "Error updating product";
        }
    }
}