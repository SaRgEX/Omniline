using System.Data.SqlTypes;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CounterpartyRepository(OmnilineDbContext context)
    : ICounterparty
{
    public async Task<IReadOnlyCollection<Counterparty>> AllAsync()
        => await context.Counterparty
            .Include(c => c.Contacts)
            .ToListAsync();

    public async Task<Counterparty?> FindAsync(int id)
        => await context.Counterparty
            .Include(c => c.Contacts)
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<int> AddAsync(Counterparty counterparty)
    {
        await context.Counterparty.AddAsync(counterparty);
        await SaveChangesAsync();
        return counterparty.Id;
    }


    public async Task<int> UpdateAsync(int id, Counterparty counterparty)
    {
        var counterparties = context.Counterparty
            .Where(c => c.Id == id);

        var res = await counterparties.ExecuteUpdateAsync(c => c
            .SetProperty(p => p.Name, counterparty.Name)
            .SetProperty(p => p.UpdatedDate, DateTimeOffset.UtcNow)
        );
        return id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        await context.Counterparty
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }

    public async Task SaveChangesAsync()
        => await context.SaveChangesAsync();
}