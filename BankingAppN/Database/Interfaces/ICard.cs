using BankingAppN.Database.Models;

namespace BankingAppN.Database.Interfaces;

public interface ICard
{
    public Task<IEnumerable<Card?>> GetAllCardsAsync();
    public Task<Card?> GetCardByIdAsync(int id);
    public Task<Card?> AddCardAsync(Card? card);
    public Card? AddCard(Card? card);
    public Task<Card> UpdateCardAsync(Card card);
    public Task DeleteCardAsync(int id);
}