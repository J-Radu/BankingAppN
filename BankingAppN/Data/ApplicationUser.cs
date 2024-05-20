using BankingApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BankingAppN.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}