using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface ISupplierRepository
    {
        Task<string> CreateSupplier(Supplier supplier, CancellationToken cancellationToken);
        Task<string> UpdateSupplier(Supplier supplier, CancellationToken cancellationToken);
        Task<Supplier> GetSupplierBy(int id, CancellationToken cancellationToken);
        Task<List<Supplier>> GetSuppliers(CancellationToken cancellationToken);
    }
}