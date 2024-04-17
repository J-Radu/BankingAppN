using System.ComponentModel.DataAnnotations;

namespace BankingAppN.Database.Models;

public class AccountOperation
{
    [Key]
    
    public int OperationId { get; set; }
    public int AccountId { get; set; }
    public string AccountNumberDestination { get; set; }
    public DateOnly OperationDate { get; set; }
    public decimal OperationAmount { get; set; }
    public string OperationType { get; set; }
    public string OperationDescription { get; set; }
    public Account? Account { get; set; }
}