using System.ComponentModel.DataAnnotations;

namespace BankingApp.Models;

public class Card
{
    [Key]
    
    public int CardID { get; set; }
    public int AccountID { get; set; }
    public string IBAN { get; set; }
    public string CardType { get; set; }
    public string CardNumber { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public Account Account { get; set; }
}