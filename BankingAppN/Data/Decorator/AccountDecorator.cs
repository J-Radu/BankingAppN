namespace BankingAppN.Data.Decorator;

public class AccountDecorator : IAccountDecorator
{
    protected readonly IAccountDecorator _accountDecorator;
    
    public AccountDecorator(IAccountDecorator accountDecorator)
    {
        _accountDecorator = accountDecorator;
    }
    public virtual decimal GetBalance()
    {
        return _accountDecorator.GetBalance();
    }
}