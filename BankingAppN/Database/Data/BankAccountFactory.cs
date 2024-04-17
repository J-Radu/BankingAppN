using BankingAppN.Database.Interfaces;

namespace BankingAppN.Database.Data;

public enum AccountType
{
    Savings,
    Checking
}

public abstract class BankAccountFactory
{
    public IBankAccount CreateAccount(AccountType type)
    {
        switch (type)
        {
            case AccountType.Savings:
                return new SavingsAccount();
            case AccountType.Checking:
                return new CheckingAccount();
            default:
                throw new ArgumentException("Invalid account type");
        }
    }
}
