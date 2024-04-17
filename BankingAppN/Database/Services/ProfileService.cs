using BankingAppN.Data;
using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;

namespace BankingAppN.Database.Services;

public class ProfileService(ApplicationDbContext context) : IProfileService
{
    public async Task<Client?> GetClientProfileAsync(int clientId)
    {
        return await context.Clients.FindAsync(clientId);
    }
    
    public async Task<Client?> UpdateClientProfileAsync(int clientId, string? name, string surname, string email, string phone, int age)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Name = name;
        client.Surname = surname;
        client.Email = email;
        client.Phone = phone;
        client.Age = age;
        await context.SaveChangesAsync();
        return client;
    }
    
    public async Task<Client?> CloneClientProfileAsync(int clientId)
    {
        var client = await context.Clients.FindAsync(clientId);
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
    
    public async Task<Client?> CreateFullClientProfileAsync(int clientId, string? name, string surname, string email, string phone, int age)
    {
        var client = new Client
        {
            ClientId = clientId,
        };
        context.Clients.Add(client);
        await SetNameAsync(clientId, name);
        await SetSurnameAsync(clientId, surname);
        await SetEmailAsync(clientId, email);
        await SetPhoneAsync(clientId, phone);
        await SetAgeAsync(clientId, age);
        await context.SaveChangesAsync();
        return client;
    }
    public async Task<Client?> SetNameAsync(int clientId, string? name)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Name = name;
        await context.SaveChangesAsync();
        return client;
    }
    public async Task<Client?> SetSurnameAsync(int clientId, string surname)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Surname = surname;
        await context.SaveChangesAsync();
        return client;
    }
    public async Task<Client?> SetEmailAsync(int clientId, string email)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Email = email;
        await context.SaveChangesAsync();
        return client;
    }
    public async Task<Client?> SetPhoneAsync(int clientId, string phone)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Phone = phone;
        await context.SaveChangesAsync();
        return client;
    }
    public async Task<Client?> SetAgeAsync(int clientId, int age)
    {
        var client = await context.Clients.FindAsync(clientId);
        if (client == null)
        {
            return null;
        }
        client.Age = age;
        await context.SaveChangesAsync();
        return client;
    }
}