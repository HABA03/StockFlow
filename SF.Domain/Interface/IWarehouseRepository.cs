using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface IWarehouseRepository
    {
        Task<string> CreateWarehouse(Warehouse warehouse, CancellationToken cancellationToken);
        Task<string> UpdateWarehouse(Warehouse warehouse, CancellationToken cancellationToken);
        Task<Warehouse> GetWarehouseBy(int id, CancellationToken cancellationToken);
        Task<List<Warehouse>> GetWarehouses(CancellationToken cancellationToken);
    }
}