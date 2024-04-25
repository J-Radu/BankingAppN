using System.ComponentModel.DataAnnotations;

namespace BankingAppN.Database.DTO;

public class AccountDto
{
    [Key]
    public int AccountId { get; set; }
    public int ClientId { get; set; }
    public string? AccountType { get; set; }
    public string? AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public DateOnly OpenDate { get; set; }
}