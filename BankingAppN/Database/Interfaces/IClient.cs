using BankingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingApp.Interfaces;

public interface IClient
{
    public Task<IEnumerable<Client>> GetAllClientsAsync();
    public Task<Client> GetClientByIdAsync(int id);
    public Task<Client> AddClientAsync(Client client);
    Client AddClient(Client client);
    public Task<Client> UpdateClientAsync(Client client);
    public Task DeleteClientAsync(int id);
}