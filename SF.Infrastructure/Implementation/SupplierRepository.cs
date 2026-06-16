using Microsoft.EntityFrameworkCore;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SFContext _context;

        public SupplierRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateSupplier(Domain.Entity.Supplier supplier, CancellationToken cancellationToken)
        {
            if(supplier == null)
                throw new Exception("Supplier cant be null");

            supplier.CreatedDated = DateTime.UtcNow;
            supplier.IsActive = true;
            await _context.Supplier.AddAsync(supplier, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Supplier created" : "Error creating supplier";
        }

        public async Task<Domain.Entity.Supplier> GetSupplierBy(int id, CancellationToken cancellationToken)
        {
            return await _context.Supplier.FirstOrDefaultAsync(s => s.Id == id, cancellationToken)?? new Domain.Entity.Supplier();
        }

        public async Task<List<Domain.Entity.Supplier>> GetSuppliers(CancellationToken cancellationToken)
        {
            return await _context.Supplier.Where(s => s.IsActive).ToListAsync(cancellationToken);
        }

        public async Task<string> UpdateSupplier(Domain.Entity.Supplier supplier, CancellationToken cancellationToken)
        {
            if(supplier == null)
                throw new Exception("Supplier cant be null");

            supplier.UpdatedDate = DateTime.UtcNow;
            supplier.IsActive = true;
            _context.Supplier.Update(supplier);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Supplier updated" : "Error updating";
        }
    }
}