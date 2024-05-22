using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankingAppN.Data;
using Microsoft.AspNetCore.Components;

namespace BankingApp.Models;

public class Client
{
    //[Key]
    
    public int ClientID { get; set; }
    //add foreig key
    [ForeignKey("ApplicationUser")]
    public string UserID { get; set; }
    public string? Name { get; set; }
    public string? Surname  { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Age { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    
    internal ICollection<Account> Accounts { get; set; } = new List<Account>();
}