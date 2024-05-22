using BankingAppN.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankingApp.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientProfileByUserIdAsync(string userId)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.UserID == userId);
        }

        public async Task<Client> CreateClientProfileAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetClientProfileAsync(int clientId)
        {
            return await _context.Clients.FindAsync(clientId);
            
        }

        public async Task<Client> UpdateClientProfileAsync(int clientId, string name, string surname, string email, string phone, string? age)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                // Throw an exception or handle the null client case appropriately
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

        public Task<Client> CloneClientProfileAsync(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Client> CreateFullClientProfileAsync(int clientId, string name, string surname, string email, string phone, string? age)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> SetNameAsync(int clientId, string name)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                // Throw an exception or handle the null client case appropriately
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
                // Throw an exception or handle the null client case appropriately
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
                // Throw an exception or handle the null client case appropriately
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
                // Throw an exception or handle the null client case appropriately
                return null;
            }
            client.Phone = phone;
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> SetAgeAsync(int clientId, string? age)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                // Throw an exception or handle the null client case appropriately
                return null;
            }
            client.Age = age;
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
