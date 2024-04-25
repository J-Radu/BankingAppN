using BankingAppN.Database.DTO;
using BankingAppN.Database.Models;

namespace BankingAppN.Database.Interfaces;

public interface IAccount
{
    public Task<IEnumerable<Account?>> GetAllAccountsAsync();
    public Task<IEnumerable<AccountDto>> GetAllAccountAsDtoAsync();
    public Task<Account?> GetAccountByIdAsync(int id);
    public Task<Account?> AddAccountAsync(Account? account);
    public Account? AddAccount(Account? account);
    public Task<Account> UpdateAccountAsync(Account account);
    public Task DeleteAccountAsync(int id);
}