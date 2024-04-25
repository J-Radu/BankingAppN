using System.ComponentModel.DataAnnotations;

namespace BankingAppN.Database.DTO;

public class AccountDto
{
    [Key]
    
    public int AccountID { get; set; }
    public int ClientID { get; set; }
    public string AccountType { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public DateOnly OpenDate { get; set; }
}