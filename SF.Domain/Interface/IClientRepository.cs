using SF.Domain.Entity;

namespace SF.Domain.Interface
{
    public interface IClientRepository
    {
        Task<string> CreateClient(Client client, CancellationToken cancellationToken);
        Task<string> UpdateClient(Client client, CancellationToken cancellationToken);
        Task<Client> GetClientBy(int id, CancellationToken cancellationToken);
        Task<List<Client>> GetClients(CancellationToken cancellationToken);
    }
}