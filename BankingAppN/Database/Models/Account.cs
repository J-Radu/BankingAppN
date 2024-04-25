using System.ComponentModel.DataAnnotations;

namespace BankingAppN.Database.Models;

public class Account
{
    [Key]
    public int AccountId { get; set; }
    public int ClientId { get; set; }
    public string? AccountType { get; set; }
    public string? AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public DateOnly OpenDate { get; set; }
    public Client? Client { get; set; }
    
    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public ICollection<AccountOperation> AccountOperations { get; set; } = new List<AccountOperation>();
}