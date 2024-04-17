using BankingAppN.Database.Models;

namespace BankingAppN.Database.Interfaces;

public interface IAccountOperation
{
    public Task<IEnumerable<AccountOperation?>> GetAllAccountOperationsAsync();
    public Task<AccountOperation?> GetAccountOperationByIdAsync(int id);
    public Task<AccountOperation?> AddAccountOperationAsync(AccountOperation? accountOperation);
    public AccountOperation? AddAccountOperation(AccountOperation? accountOperation);
    public Task<AccountOperation> UpdateAccountOperationAsync(AccountOperation accountOperation);
    public Task DeleteAccountOperationAsync(int id);
}