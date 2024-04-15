using BankingApp.Data;
using BankingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankingAppN.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
   
    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountOperation> AccountOperations { get; set; }
    public DbSet<Card> Cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Account>()
            // .HasKey( a => new { a.AccountID, a.ClientID })
            .HasOne(a => a.Client)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.ClientID)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<AccountOperation>()
            .HasOne( a => a.Account)
            .WithMany(ac => ac.AccountOperations)
            .HasForeignKey(a => a.AccountID)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Card>()
            .HasOne(a => a.Account)
            .WithMany(c => c.Cards)
            .HasForeignKey(a => a.AccountID)
            .OnDelete(DeleteBehavior.Cascade);

    }
}