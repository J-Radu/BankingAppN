using BankingAppN.Database.Models;

namespace BankingAppN.Database.Interfaces;

public interface IProfileService
{
    Task<Client?> GetClientProfileAsync(int clientId);
    Task<Client?> UpdateClientProfileAsync(int clientId, string? name, string surname, string email, string phone, int age);
    Task<Client?> CloneClientProfileAsync(int clientId);
    Task<Client?> CreateFullClientProfileAsync(int clientId, string? name, string surname, string email, string phone, int age); 
    Task<Client?> SetNameAsync(int clientId, string? name);
    Task<Client?> SetSurnameAsync(int clientId, string surname);
    Task<Client?> SetEmailAsync(int clientId, string email);
    Task<Client?> SetPhoneAsync(int clientId, string phone);
    Task<Client?> SetAgeAsync(int clientId, int age);
    
}