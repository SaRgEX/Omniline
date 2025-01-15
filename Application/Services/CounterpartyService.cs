using Application.Contracts;
using Application.Models.Counterparties;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CounterpartyService(ICounterparty counterpartyRepository, IMapper mapper)
    : ICounterpartyService
{
    public async Task<IReadOnlyCollection<CounterpartyResponse>> AllAsync()
    {
        var counterparties = await counterpartyRepository.AllAsync();
        return mapper.Map<IReadOnlyCollection<CounterpartyResponse>>(counterparties);
    }

    public async Task<CounterpartyResponse?> FindAsync(int id)
    {
        var counterparty = await counterpartyRepository.FindAsync(id);
        return mapper.Map<CounterpartyResponse>(counterparty);
    }

    public Task<int> Create(CounterpartyRequest counterparty)
    {
        return counterpartyRepository.AddAsync(mapper.Map<Counterparty>(counterparty));
    }

    public Task<int> UpdateAsync(int id, CounterpartyRequest counterparty)
    {
        return counterpartyRepository.UpdateAsync(id, mapper.Map<Counterparty>(counterparty));
    }

    public Task<int> DeleteAsync(int id)
    {
        return counterpartyRepository.DeleteAsync(id);
    }
}