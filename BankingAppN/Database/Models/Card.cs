using System.ComponentModel.DataAnnotations;

namespace BankingAppN.Database.Models;

public class Card
{
    [Key]
    
    public int CardId { get; set; }
    public int AccountId { get; set; }
    public string IBAN { get; set; }
    public string CardType { get; set; }
    public string CardNumber { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public Account? Account { get; set; }
}