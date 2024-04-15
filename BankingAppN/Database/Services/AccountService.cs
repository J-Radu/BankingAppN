using BankingApp.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services;

public class AccountService : IAccount
{
    private readonly ApplicationDbContext _context;
    
    public AccountService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
        return await _context.Accounts.ToListAsync();
    }
    public async Task<Account> GetAccountByIdAsync(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }
    public async Task<Account> AddAccountAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }
    public Account AddAccount(Account account)
    {
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return account;
    }
    public async Task<Account> UpdateAccountAsync(Account account)
    {
        _context.Entry(account).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return account;
    }
    public async Task DeleteAccountAsync(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}