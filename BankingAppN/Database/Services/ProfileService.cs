using BankingApp.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Data;

namespace BankingApp.Services;

public class ProfileService : IProfileService
{
    private readonly ApplicationDbContext _context;
    public ProfileService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Client> GetClientProfileAsync(int clientId)
    {
        return await _context.Clients.FindAsync(clientId);
    }
    
    public async Task<Client> UpdateClientProfileAsync(int clientId, string name, string surname, string email, string phone, int age)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Name = name;
        client.Surname = surname;
        client.Email = email;
        client.Phone = phone;
        client.Age = age;
        await _context.SaveChangesAsync();
        return client;
    }
    
    public async Task<Client> CloneClientProfileAsync(int clientId)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        var newClient = new Client
        {
            Name = client.Name,
            Surname = client.Surname,
            Email = client.Email,
            Phone = client.Phone,
            Age = client.Age
        };
        // _context.Clients.Add(newClient);
        // await _context.SaveChangesAsync();
        return newClient;
    }
    
    public async Task<Client> CreateFullClientProfileAsync(int clientId, string name, string surname, string email, string phone, int age)
    {
        var client = new Client
        {
            ClientID = clientId,
        };
        _context.Clients.Add(client);
        await SetNameAsync(clientId, name);
        await SetSurnameAsync(clientId, surname);
        await SetEmailAsync(clientId, email);
        await SetPhoneAsync(clientId, phone);
        await SetAgeAsync(clientId, age);
        await _context.SaveChangesAsync();
        return client;
    }
    public async Task<Client> SetNameAsync(int clientId, string name)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Name = name;
        await _context.SaveChangesAsync();
        return client;
    }
    public async Task<Client> SetSurnameAsync(int clientId, string surname)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Surname = surname;
        await _context.SaveChangesAsync();
        return client;
    }
    public async Task<Client> SetEmailAsync(int clientId, string email)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Email = email;
        await _context.SaveChangesAsync();
        return client;
    }
    public async Task<Client> SetPhoneAsync(int clientId, string phone)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Phone = phone;
        await _context.SaveChangesAsync();
        return client;
    }
    public async Task<Client> SetAgeAsync(int clientId, int age)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Age = age;
        await _context.SaveChangesAsync();
        return client;
    }
}