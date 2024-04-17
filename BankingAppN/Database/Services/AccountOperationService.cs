using BankingAppN.Data;
using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppN.Database.Services;

public class AccountOperationService(ApplicationDbContext context) : IAccountOperation
{
    public async Task<IEnumerable<AccountOperation?>> GetAllAccountOperationsAsync()
    {
        return await context.AccountOperations.ToListAsync();
    }
    public async Task<AccountOperation?> GetAccountOperationByIdAsync(int id)
    {
        return await context.AccountOperations.FindAsync(id);
    }
    public async Task<AccountOperation?> AddAccountOperationAsync(AccountOperation? accountOperation)
    {
        context.AccountOperations.Add(accountOperation);
        await context.SaveChangesAsync();
        return accountOperation;
    }
    public AccountOperation? AddAccountOperation(AccountOperation? accountOperation)
    {
        context.AccountOperations.Add(accountOperation);
        context.SaveChanges();
        return accountOperation;
    }
    public async Task<AccountOperation> UpdateAccountOperationAsync(AccountOperation accountOperation)
    {
        context.Entry(accountOperation).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return accountOperation;
    }
    public async Task DeleteAccountOperationAsync(int id)
    {
        var accountOperation = await context.AccountOperations.FindAsync(id);
        context.AccountOperations.Remove(accountOperation);
        await context.SaveChangesAsync();
    }
}