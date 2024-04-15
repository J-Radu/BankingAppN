using BankingApp.Models;

namespace BankingApp.Interfaces;

public interface IAccount
{
    public Task<IEnumerable<Account>> GetAllAccountsAsync();
    public Task<Account> GetAccountByIdAsync(int id);
    public Task<Account> AddAccountAsync(Account account);
    public Account AddAccount(Account account);
    public Task<Account> UpdateAccountAsync(Account account);
    public Task DeleteAccountAsync(int id);
}