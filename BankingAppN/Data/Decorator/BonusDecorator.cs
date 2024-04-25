namespace BankingAppN.Data.Decorator;

public class BonusDecorator : AccountDecorator
{
    private readonly decimal _bonusAmount;
    
    public BonusDecorator(IAccountDecorator accountDecorator, decimal bonusAmount) : base(accountDecorator)
    {
        _bonusAmount = bonusAmount;
    }
    
    public decimal GetBalance()
    {
        return base.GetBalance() + _bonusAmount;
    }
}