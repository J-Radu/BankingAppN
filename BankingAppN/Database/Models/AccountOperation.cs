using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models;

public class AccountOperation
{
    [Key]
    
    public int OperationID { get; set; }
    public int AccountID { get; set; }
    public string AccountNumber { get; set; }
    public DateOnly OperationDate { get; set; }
    public decimal OperationAmount { get; set; }
    public string OperationType { get; set; }
    public string OperationDescription { get; set; }
    public Account? Account { get; set; }
}