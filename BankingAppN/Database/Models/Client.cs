using System.ComponentModel.DataAnnotations;

namespace BankingAppN.Database.Models;

public class Client
{
    [Key]
    
    public int ClientId { get; set; }
    public string? Name { get; set; }
    public string Surname  { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    
    internal ICollection<Account> Accounts { get; set; } = new List<Account>();
}