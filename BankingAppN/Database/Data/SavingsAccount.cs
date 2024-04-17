using BankingAppN.Database.Interfaces;

namespace BankingAppN.Database.Data;

public class SavingsAccount : IBankAccount
{
    public string AccountType => "Savings Account";
    public decimal Balance { get; private set; }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds");
        }
    }
}