using Application.Models.Counterparties;
using Domain.Entities;

namespace Application.Contracts;

public interface ICounterpartyService
{
    Task<IReadOnlyCollection<CounterpartyResponse>> AllAsync();
    Task<CounterpartyResponse?> FindAsync(int id);
    Task<int> Create(CounterpartyRequest counterparty);
    Task<int> UpdateAsync(int id, CounterpartyRequest counterparty);
    Task<int> DeleteAsync(int id);
}