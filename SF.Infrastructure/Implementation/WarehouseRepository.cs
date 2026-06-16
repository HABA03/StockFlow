using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly SFContext _context;

        public WarehouseRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateWarehouse(Warehouse warehouse, CancellationToken cancellationToken)
        {
            if(warehouse == null)
                throw new Exception("Warehoyse is null");

            warehouse.CreatedDate = DateTime.UtcNow;
            warehouse.IsActive = true;
            await _context.Warehouse.AddAsync(warehouse, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Warehouse created" : "Error creating warehouse";
        }

        public async Task<Warehouse> GetWarehouseBy(int id, CancellationToken cancellationToken)
        {
            return await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == id, cancellationToken)?? new Warehouse();
        }

        public async Task<List<Warehouse>> GetWarehouses(CancellationToken cancellationToken)
        {
            return await _context.Warehouse.Where(w => w.IsActive).ToListAsync(cancellationToken);
        }

        public async Task<string> UpdateWarehouse(Warehouse warehouse, CancellationToken cancellationToken)
        {
            if(warehouse == null)
                throw new Exception("Warehose cant be null");

            warehouse.UpdatedDate = DateTime.UtcNow;
            warehouse.IsActive = true;
            _context.Warehouse.Update(warehouse);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Warehouse updated" : "Error updating warehouse";
        }
    }
}