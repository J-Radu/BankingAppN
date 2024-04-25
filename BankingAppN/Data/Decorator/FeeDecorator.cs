namespace BankingAppN.Data.Decorator;

public class FeeDecorator : AccountDecorator
{
    private readonly decimal _feeAmount;
    
    public FeeDecorator(IAccountDecorator accountDecorator, decimal feeAmount) : base(accountDecorator)
    {
        _feeAmount = feeAmount;
    }
    
    public override decimal GetBalance()
    {
        return base.GetBalance() - _feeAmount;
    }
}