using BankingAppN.Data;
using BankingAppN.Database.Data;
using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppN.Database.Services;

public class ClientService(ApplicationDbContext context, BankAccountFactory accountFactory)
    : IClient
{
    public async Task<IEnumerable<Client?>> GetAllClientsAsync()
    {
        return await context.Clients.ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(int id)
    {
        return await context.Clients.FindAsync(id);
    }

    public async Task<Client?> AddClientAsync(Client? client)
    {
        context.Clients.Add(client);
        await context.SaveChangesAsync();
        return client;
    }
    
    public Client? AddClient(Client? client)
    {
        context.Clients.Add(client);
        context.SaveChanges();
        return client;
    }

    public async Task<Client> UpdateClientAsync(Client client)
    {
        context.Entry(client).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return client;
    }

    public async Task DeleteClientAsync(int id)
    {
        var client = await context.Clients.FindAsync(id);
        context.Clients.Remove(client);
        await context.SaveChangesAsync();
    }
    //Metoda pentru factory method
    public ClientService(BankAccountFactory accountFactory) : this(null, accountFactory)
    {
    }

    public IBankAccount OpenAccount(AccountType type)
    {
        return accountFactory.CreateAccount(type);
    }
    
}