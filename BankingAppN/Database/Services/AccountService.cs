using BankingAppN.Data;
using BankingAppN.Database.DTO;
using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppN.Database.Services;

public class AccountService(ApplicationDbContext context) : IAccount
{
    public async Task<IEnumerable<Account?>> GetAllAccountsAsync()
    {
        return await context.Accounts.ToListAsync();
    }
    public async Task<IEnumerable<AccountDto>> GetAllAccountAsDtoAsync()
    {
        return await context.Accounts
            .Select(a => new AccountDto
            {
                AccountId = a.AccountId,
                ClientId = a.ClientId,
                AccountType = a.AccountType,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                OpenDate = a.OpenDate,
            }).ToListAsync();
    }
    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        return await context.Accounts.FindAsync(id);
    }

    public async Task<AccountDto> GetAccountByIdAsDtoAsync(int id)
    {
        return await context.Accounts
            .Where(a => a.AccountId == id)
            .Select(a => new AccountDto
            {
                AccountId = a.AccountId,
                ClientId = a.ClientId,
                AccountType = a.AccountType,
                AccountNumber = a.AccountNumber,
                Balance = a.Balance,
                OpenDate = a.OpenDate,
            }).FirstOrDefaultAsync();
    }
    public async Task<Account?> AddAccountAsync(Account? account)
    {
        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return account;
    }
    public async Task<AccountDto> AddAccountDtoAsync(AccountDto accountDto)
    {
        var account = new Account
        {
            AccountId = accountDto.AccountId,
            ClientId = accountDto.ClientId,
            AccountType = accountDto.AccountType,
            AccountNumber = accountDto.AccountNumber,
            Balance = accountDto.Balance,
            OpenDate = accountDto.OpenDate,
        };
        context.Accounts.Add(account);
        await context.SaveChangesAsync();
        return accountDto;
    }
    public Account? AddAccount(Account? account)
    {
        context.Accounts.Add(account);
        context.SaveChanges();
        return account;
    }
    public async Task<Account> UpdateAccountAsync(Account account)
    {
        context.Entry(account).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return account;
    }
    public async Task<AccountDto> UpdateAccountDtoAsync(AccountDto accountDto)
    {
        var account = new Account
        {
            AccountId = accountDto.AccountId,
            ClientId = accountDto.ClientId,
            AccountType = accountDto.AccountType,
            AccountNumber = accountDto.AccountNumber,
            Balance = accountDto.Balance,
            OpenDate = accountDto.OpenDate,
        };
        context.Entry(account).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return accountDto;
    }
    public async Task DeleteAccountAsync(int id)
    {
        var account = await context.Accounts.FindAsync(id);
        context.Accounts.Remove(account);
        await context.SaveChangesAsync();
    }
}