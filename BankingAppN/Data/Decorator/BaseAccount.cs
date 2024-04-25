namespace BankingAppN.Data.Decorator;

public class BaseAccount : IAccountDecorator
{
    private decimal _balance;

    public BaseAccount(decimal balance)
    {
        _balance = balance;
    }
    
    public decimal GetBalance()
    {
        return _balance;
    }
}