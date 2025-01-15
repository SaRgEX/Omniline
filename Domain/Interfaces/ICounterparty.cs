using Domain.Entities;

namespace Domain.Interfaces;

public interface ICounterparty
{
    Task<IReadOnlyCollection<Counterparty>> AllAsync();
    Task<Counterparty?> FindAsync(int id);
    Task<int> AddAsync(Counterparty counterparty);
    Task<int> UpdateAsync(int id, Counterparty counterparty);
    Task<int> DeleteAsync(int id);
    Task SaveChangesAsync();
}