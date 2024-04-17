using BankingApp.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Data;
using BankingAppN.Database.DTO;
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
    public async Task<IEnumerable<AccountDto>> GetAllAccountAsDtoAsync()
    {
        return await _context.Accounts
            .Select(a => new AccountDto
            {
                AccountID = a.AccountID,
                ClientID = a.ClientID,
                AccountType = a.AccountType,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                OpenDate = a.OpenDate,
            }).ToListAsync();
    }
    public async Task<Account> GetAccountByIdAsync(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<AccountDto> GetAccountByIdAsDtoAsync(int id)
    {
        return await _context.Accounts
            .Where(a => a.AccountID == id)
            .Select(a => new AccountDto
            {
                AccountID = a.AccountID,
                ClientID = a.ClientID,
                AccountType = a.AccountType,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                OpenDate = a.OpenDate,
            }).FirstOrDefaultAsync();
    }
    public async Task<Account> AddAccountAsync(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }
    public async Task<AccountDto> AddAccountDtoAsync(AccountDto accountDto)
    {
        var account = new Account
        {
            AccountID = accountDto.AccountID,
            ClientID = accountDto.ClientID,
            AccountType = accountDto.AccountType,
            AccountNumber = accountDto.AccountNumber,
            Balance = accountDto.Balance,
            OpenDate = accountDto.OpenDate,
        };
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return accountDto;
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
    public async Task<AccountDto> UpdateAccountDtoAsync(AccountDto accountDto)
    {
        var account = new Account
        {
            AccountID = accountDto.AccountID,
            ClientID = accountDto.ClientID,
            AccountType = accountDto.AccountType,
            AccountNumber = accountDto.AccountNumber,
            Balance = accountDto.Balance,
            OpenDate = accountDto.OpenDate,
        };
        _context.Entry(account).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return accountDto;
    }
    public async Task DeleteAccountAsync(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}