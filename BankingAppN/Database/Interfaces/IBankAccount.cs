namespace BankingApp.Interfaces;

public interface IBankAccount
{
    string AccountType { get; }
    decimal Balance { get; }
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
}