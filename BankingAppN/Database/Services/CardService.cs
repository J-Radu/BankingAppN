using BankingAppN.Data;
using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppN.Database.Services;

public class CardService(ApplicationDbContext context) : ICard
{
    public async Task<IEnumerable<Card?>> GetAllCardsAsync()
    {
        return await context.Cards.ToListAsync();
    }
    public async Task<Card?> GetCardByIdAsync(int id)
    {
        return await context.Cards.FindAsync(id);
    }
    public async Task<Card?> AddCardAsync(Card? card)
    {
        context.Cards.Add(card);
        await context.SaveChangesAsync();
        return card;
    }
    public Card? AddCard(Card? card)
    {
        context.Cards.Add(card);
        context.SaveChanges();
        return card;
    }
    public async Task<Card> UpdateCardAsync(Card card)
    {
        context.Entry(card).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return card;
    }
    public async Task DeleteCardAsync(int id)
    {
        var card = await context.Cards.FindAsync(id);
        context.Cards.Remove(card);
        await context.SaveChangesAsync();
    }
}