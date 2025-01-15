using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ContactRepository(OmnilineDbContext context)
    : IContact
{
    public async Task<IReadOnlyCollection<Contact>> AllAsync()
        => await context.Contacts.ToListAsync();


    public async Task<Contact?> FindAsync(int id)
        => await context.Contacts.FindAsync(id);


    public async Task<int> AddAsync(Contact contact)
    {
        await context.Contacts.AddAsync(contact);
        await SaveChangesAsync();
        return contact.Id;
    }

    public async Task<int> UpdateAsync(int id, Contact contact)
    {
        var contacts = context.Contacts
            .Where(c => c.Id == id);

        await contacts.ExecuteUpdateAsync(c => c
            .SetProperty(p => p.FirstName, contact.FirstName)
            .SetProperty(p => p.LastName, contact.LastName)
            .SetProperty(p => p.Patronymic, contact.Patronymic)
            .SetProperty(p => p.Email, contact.Email)
            .SetProperty(p => p.CounterpartyId, contact.CounterpartyId)
            .SetProperty(p => p.UpdatedDate, DateTimeOffset.UtcNow)
        );

        return contact.Id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        await context.Contacts
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }

    public async Task SaveChangesAsync()
        => await context.SaveChangesAsync();
}