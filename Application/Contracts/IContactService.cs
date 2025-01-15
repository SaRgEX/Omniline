using Application.Models.Contacts;

namespace Application.Contracts;

public interface IContactService
{
    Task<IReadOnlyCollection<ContactResponse>> AllAsync();
    Task<ContactResponse?> FindAsync(int id);
    Task<int> Create(ContactRequest contact);
    Task<int> UpdateAsync(int id, ContactRequest contact);
    Task<int> DeleteAsync(int id);
}