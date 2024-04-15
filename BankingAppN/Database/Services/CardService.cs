using BankingApp.Data;
using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Services;

public class CardService : ICard
{
    private readonly ApplicationDbContext _context;
    public CardService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Card>> GetAllCardsAsync()
    {
        return await _context.Cards.ToListAsync();
    }
    public async Task<Card> GetCardByIdAsync(int id)
    {
        return await _context.Cards.FindAsync(id);
    }
    public async Task<Card> AddCardAsync(Card card)
    {
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();
        return card;
    }
    public Card AddCard(Card card)
    {
        _context.Cards.Add(card);
        _context.SaveChanges();
        return card;
    }
    public async Task<Card> UpdateCardAsync(Card card)
    {
        _context.Entry(card).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return card;
    }
    public async Task DeleteCardAsync(int id)
    {
        var card = await _context.Cards.FindAsync(id);
        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();
    }
}