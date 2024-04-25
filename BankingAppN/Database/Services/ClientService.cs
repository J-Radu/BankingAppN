using BankingApp.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services;

public class ClientService : IClient
{
    private readonly ApplicationDbContext _context;
    private readonly BankAccountFactory _accountFactory;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetClientByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }
    
    public Client AddClient(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
        return client;
    }

    public async Task<Client> UpdateClientAsync(Client client)
    {
        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task DeleteClientAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
    }
    //Metoda pentru factory method
    public ClientService(BankAccountFactory accountFactory)
    {
        _accountFactory = accountFactory;
    }

    public IBankAccount OpenAccount(AccountType type)
    {
        return _accountFactory.CreateAccount(type);
    }
    
}