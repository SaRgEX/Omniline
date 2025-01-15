using Domain.Entities;

namespace Domain.Interfaces;

public interface IContact
{
    Task<IReadOnlyCollection<Contact>> AllAsync();
    Task<Contact?> FindAsync(int id);
    Task<int> AddAsync(Contact contact);
    Task<int> UpdateAsync(int id, Contact contact);
    Task<int> DeleteAsync(int id);
    Task SaveChangesAsync();
}