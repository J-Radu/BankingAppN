namespace BankingAppN.Data.Decorator;

public class InterestDecorator : AccountDecorator
{
    private readonly decimal _interestRate;
    
    public InterestDecorator(IAccountDecorator accountDecorator, decimal interestRate) : base(accountDecorator)
    {
        _interestRate = interestRate;
    }
    
    public override decimal GetBalance()
    {
        return base.GetBalance() * (1 + _interestRate);
    }
}