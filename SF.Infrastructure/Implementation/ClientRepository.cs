using Microsoft.EntityFrameworkCore;
using SF.Domain.Entity;
using SF.Domain.Enum;
using SF.Domain.Interface;
using SF.Infrastructure.Context;

namespace SF.Infrastructure.Implementation
{
    public class ClientRepository : IClientRepository
    {
        private readonly SFContext _context;

        public ClientRepository(SFContext context)
        {
            _context = context;
        }

        public async Task<string> CreateClient(Client client, CancellationToken cancellationToken)
        {
            if(client == null)
                throw new Exception("Client is null");

            client.Status = ClientStatusEnum.Active;
            client.CreatedDate = DateTime.UtcNow;
            await _context.Client.AddAsync(client, cancellationToken);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Client created" : "Error creating client";
        }

        public async Task<Client> GetClientBy(int id, CancellationToken cancellationToken)
        {
            return await _context.Client.FirstOrDefaultAsync(c => c.Id == id, cancellationToken)?? new Client();
        }

        public async Task<List<Client>> GetClients(CancellationToken cancellationToken)
        {
            return await _context.Client.Where(c => c.Status != ClientStatusEnum.Deleted).ToListAsync(cancellationToken);
        }

        public async Task<string> UpdateClient(Client client, CancellationToken cancellationToken)
        {
            if(client == null)
                throw new Exception("Client cant be null");

            _context.Client.Update(client);
            var response = await _context.SaveChangesAsync(cancellationToken) > 0;
            return response ? "Client updated" : "Error updating client";
        }
    }
}