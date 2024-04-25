using BankingApp.Interfaces;

namespace BankingApp.Data;

public enum AccountType
{
    Savings,
    Checking
}

public class BankAccountFactory
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
