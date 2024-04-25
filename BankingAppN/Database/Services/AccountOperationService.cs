using BankingApp.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services;

public class AccountOperationService : IAccountOperation
{
    private readonly ApplicationDbContext _context;
    
    public AccountOperationService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<AccountOperation>> GetAllAccountOperationsAsync()
    {
        return await _context.AccountOperations.ToListAsync();
    }
    public async Task<AccountOperation> GetAccountOperationByIdAsync(int id)
    {
        return await _context.AccountOperations.FindAsync(id);
    }
    public async Task<AccountOperation> AddAccountOperationAsync(AccountOperation accountOperation)
    {
        _context.AccountOperations.Add(accountOperation);
        await _context.SaveChangesAsync();
        return accountOperation;
    }
    public AccountOperation AddAccountOperation(AccountOperation accountOperation)
    {
        _context.AccountOperations.Add(accountOperation);
        _context.SaveChanges();
        return accountOperation;
    }
    public async Task<AccountOperation> UpdateAccountOperationAsync(AccountOperation accountOperation)
    {
        _context.Entry(accountOperation).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return accountOperation;
    }
    public async Task DeleteAccountOperationAsync(int id)
    {
        var accountOperation = await _context.AccountOperations.FindAsync(id);
        _context.AccountOperations.Remove(accountOperation);
        await _context.SaveChangesAsync();
    }
}