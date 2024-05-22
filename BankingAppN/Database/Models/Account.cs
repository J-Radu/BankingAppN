using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models;

public class Account
{
    [Key]
    
    public int AccountID { get; set; }
    public int ClientID { get; set; }
    public string? AccountType { get; set; }
    public string? AccountNumber { get; set; }
    public decimal? Balance { get; set; }
    public DateOnly? OpenDate { get; set; }
    public Client? Client { get; set; }
    
    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public ICollection<AccountOperation> AccountOperations { get; set; } = new List<AccountOperation>();
    
}